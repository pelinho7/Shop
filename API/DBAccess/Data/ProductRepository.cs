using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using API.Helpers;
using System;
using API.DBAccess.Interfaces;
using API.DBAccess.Entities;
using API.DBAccess.Data;
using System.Text;
using Microsoft.Extensions.Logging;

namespace API.DBAccess.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly ILogger<UnitOfWork> logger;

        public ProductRepository(DataContext context, IMapper mapper, ILogger<UnitOfWork> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        public async Task<Product> GetProductByCode(string code)
        {
            return await context.Products
            .Where(x => x.Code == code)
            .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await context.Products.Include(x => x.Photos.Where(z => !z.Deleted))
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductFullData(string code)
        {
            var query = context.Products
            .Include(x => x.Photos.Where(x => !x.Deleted))
            .Include(x => x.Discounts.Where(x => !x.Deleted && x.StartDate>=DateTime.UtcNow && x.EndDate<=DateTime.UtcNow))
            .Include(x => x.ProductTextAttributes.Where(x => !x.Deleted)).ThenInclude(x => x.Attribute)
            .Include(x => x.ProductNumberAttributes.Where(x => !x.Deleted)).ThenInclude(x => x.Attribute)
            .Where(x => x.Code == code && !x.Deleted).AsQueryable();

            return await query.FirstOrDefaultAsync();
        }

        private List<int> getProductIdsFilteredByPrice(decimal? pMin = null, decimal? pMax = null)
        {
            var date = new Microsoft.Data.Sqlite.SqliteParameter("@date", DateTime.UtcNow);
            var priceMin = new Microsoft.Data.Sqlite.SqliteParameter("@priceMin", -1);
            var priceMax = new Microsoft.Data.Sqlite.SqliteParameter("@priceMax", 99999999999.0);
            if (pMin.HasValue && pMin.Value > 0)
            {
                priceMin = new Microsoft.Data.Sqlite.SqliteParameter("@priceMin", (double)pMin.Value);
            }
            if (pMax.HasValue)
            {
                priceMax = new Microsoft.Data.Sqlite.SqliteParameter("@priceMax", (double)pMax.Value);
            }
            StringBuilder sb = new StringBuilder();

            sb.Append(@"select DISTINCT p.Id
                from Products p
                left join Discounts dp on p.Id=dp.ProductId and dp.StartDate<=@date and dp.EndDate>=@date
                left join Discounts dc on p.CategoryId=dc.CategoryId and dc.StartDate<=@date and dc.EndDate>=@date
                where (case when dp.Type=0 THEN p.Price*(100-dp.Value)/100 when dp.Type=1 THEN p.Price*-dp.Value else p.Price end) BETWEEN @priceMin and @priceMax
                or (case when dc.Type=0 THEN p.Price*(100-dc.Value)/100 when dc.Type=1 THEN p.Price*-dc.Value else p.Price end) BETWEEN @priceMin and @priceMax");

            //         sb.Append(@"select DISTINCT p.Id
            // from Products p
            // left join Discounts dp on p.Id=dp.ProductId and dp.StartDate<=@date and dp.EndDate>=@date
            // left join Discounts dc on p.CategoryId=dc.CategoryId and dc.StartDate<=@date and dc.EndDate>=@date
            // where (case when dp.Type=0 THEN p.Price*(100-dp.Value)/100 when dp.Type=1 THEN p.Price*-dp.Value else p.Price end) BETWEEN CAST(@priceMin as decimal) and @priceMax
            // or (case when dc.Type=0 THEN p.Price*(100-dc.Value)/100 when dc.Type=1 THEN p.Price*-dc.Value else p.Price end) BETWEEN CAST(@priceMin as decimal) and @priceMax");



            return context.Products
            .FromSqlRaw(sb.ToString(), date, priceMin, priceMax)
            .Select(x => x.Id).ToList();
        }

        public async Task<PagedList<Product>> GetProducts(Pagination pagination
        , List<int> categories
        , List<DefaultParamFilter> defaultParamFilters
        , List<TextAttributeFilter> textAttributeFilters
        , List<NumberAttributeFilter> numberAttributeFilters
        , List<CheckboxAttributeFilter> checkboxAttributeFilters)
        {

            List<int> productPriceIdList = null;
            var priceFilters = defaultParamFilters.Where(x => x.Type == DefaultFilterParamEnum.Price).ToList();
            if (priceFilters != null && priceFilters.Any())
            {
                decimal? pMax = (decimal?)priceFilters.FirstOrDefault(x => !x.GreaterThen)?.Value;
                decimal? pMin = (decimal?)priceFilters.FirstOrDefault(x => x.GreaterThen)?.Value;
                productPriceIdList = getProductIdsFilteredByPrice(pMin.HasValue ? pMin : 0, pMax);
            }
            //var query = context.Products

            //var query = context.Products.Include(x => x.Discounts.Where(x => x.Id == 0))
             var query = context.Products.Include(x => x.Discounts.Where(x=>!x.Deleted && x.StartDate>=DateTime.UtcNow && x.EndDate<=DateTime.UtcNow))
             //query = query.Include(x => x.Discounts.Where(x=>x.StartDate>=DateTime.UtcNow))
             .Include(x => x.Photos.Where(x => !x.Deleted))
             .Include(x => x.ProductTextAttributes.Where(x => !x.Deleted))
             .Include(x => x.ProductNumberAttributes.Where(x => !x.Deleted)).AsQueryable();
            query = query.Where(x => !x.Deleted && !x.Temporary && categories.Contains(x.CategoryId.Value));
            numberAttributeFilters.ForEach(atr =>
            {
                if (atr.GreaterThen)
                {
                    query = query.Where(x => x.ProductNumberAttributes.Any(y => y.Value >= (decimal)atr.Value && y.AttributeId == atr.AttributeId));
                }
                else
                {
                    query = query.Where(x => x.ProductNumberAttributes.Any(y => y.Value <= (decimal)atr.Value && y.AttributeId == atr.AttributeId));
                }
            });

            textAttributeFilters.ForEach(atr =>
            {
                query = query.Where(x => !x.ProductTextAttributes.Any(y => y.Value.ToLower().Contains(atr.Value.ToLower()) && y.AttributeId == atr.AttributeId));
            });

            checkboxAttributeFilters.ForEach(atr =>
            {
                query = query.Where(x => !x.ProductTextAttributes.Any(y => atr.Values.Contains(y.Value) && y.AttributeId == atr.AttributeId));
            });

            if (productPriceIdList != null)
            {
                query = query.Where(x => productPriceIdList.Contains(x.Id));
            }

            return await PagedList<Product>.CreateAsync(
                query.AsNoTracking()
                , pagination.Page, pagination.ItemsPerPage);
            // return await PagedList<ProductListItemDto>.CreateAsync(
            //     query.ProjectTo<ProductListItemDto>(mapper.ConfigurationProvider).AsNoTracking()
            //     , pagination.Page, pagination.ItemsPerPage);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var p = await context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            if (!string.IsNullOrEmpty(product.Code)) p.Code = product.Code;
            p.Name = product.Name;
            p.CategoryId = product.CategoryId;
            p.Price = product.Price;
            p.Description = product.Description;
            p.Temporary = false;
            p.Deleted = p.Deleted;
            p.ModDate = System.DateTime.UtcNow;
            return p;
        }

        public async Task<PagedList<ProductBasicDto>> GetProductsManagment(string code, int? categoryId, Pagination pagination)
        {
            var query = context.Products
            .Where(x => !x.Deleted && !x.Temporary).AsQueryable();
            if (!string.IsNullOrEmpty(code)) query = query.Where(x => x.Code.ToUpper().Contains(code.ToUpper())).AsQueryable();
            if (categoryId.HasValue) query = query.Where(x => x.CategoryId == categoryId.Value).AsQueryable();


            return await PagedList<ProductBasicDto>.CreateAsync(
                query.ProjectTo<ProductBasicDto>(mapper.ConfigurationProvider).AsNoTracking()
                , pagination.Page, pagination.ItemsPerPage);
        }

        public async void DeleteProduct(int productId)
        {
            var productToDelete = await context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            productToDelete.Deleted = true;
        }

        public async void RemoveTemporaryProducts()
        {
            var productsToRemove = await context.Products
            .Where(x => x.Temporary && x.CreateDate < DateTime.UtcNow.AddDays(-7))
            .ToListAsync();
            context.Products.RemoveRange(productsToRemove);
        }
    }
}