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

namespace API.DBAccess.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);     
        }

        public async Task<Product> GetProductByCode(string code)
        {
            return await context.Products
            .Where(x=>x.Code==code)
            .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await context.Products.Include(x=>x.Photos.Where(z=>!z.Deleted))
            .Where(x=>x.Id==id)
            .FirstOrDefaultAsync();
        }

        private List<int> getProductIdsFilteredByPrice(decimal? pMin = null,decimal? pMax=null)
        {
            var date = new Microsoft.Data.Sqlite.SqliteParameter("@date", DateTime.UtcNow);
            var priceMin = new Microsoft.Data.Sqlite.SqliteParameter("@priceMin", -1);
            var priceMax = new Microsoft.Data.Sqlite.SqliteParameter("@priceMax", 99999999999);
            if(pMin.HasValue && pMin.Value>0){
                priceMin = new Microsoft.Data.Sqlite.SqliteParameter("@priceMin", pMin.Value);
            }
            if(pMax.HasValue){
                priceMax = new Microsoft.Data.Sqlite.SqliteParameter("@priceMax", pMax.Value);
            }
            StringBuilder sb=new StringBuilder();
            // sb.AppendLine("select DISTINCT p.*");
            // sb.AppendLine("from Products p");
            // sb.AppendLine("left join Discounts dp on p.Id=dp.ProductId and dp.StartDate<=@date and dp.EndDate>=@date");
            // sb.AppendLine("left join Discounts dc on p.CategoryId=dc.CategoryId and dc.StartDate<=@date and dc.EndDate>=@date");
            // sb.AppendLine("where (case when dp.Type=0 THEN p.Price*(100-dp.Value)/100 when dp.Type=1 THEN p.Price*-dp.Value else p.Price end) BETWEEN @priceMin and @priceMax");
            // sb.AppendLine("or (case when dc.Type=0 THEN p.Price*(100-dc.Value)/100 when dc.Type=1 THEN p.Price*-dc.Value else p.Price end) BETWEEN @priceMin and @priceMax");
            sb.Append(@"select DISTINCT p.Id
                from Products p
                left join Discounts dp on p.Id=dp.ProductId and dp.StartDate<=@date and dp.EndDate>=@date
                left join Discounts dc on p.CategoryId=dc.CategoryId and dc.StartDate<=@date and dc.EndDate>=@date
                where (case when dp.Type=0 THEN p.Price*(100-dp.Value)/100 when dp.Type=1 THEN p.Price*-dp.Value else p.Price end) BETWEEN @priceMin and @priceMax
                or (case when dc.Type=0 THEN p.Price*(100-dc.Value)/100 when dc.Type=1 THEN p.Price*-dc.Value else p.Price end) BETWEEN @priceMin and @priceMax");
            return context.Products
            .FromSqlRaw(sb.ToString(),date,priceMin,priceMax)
            .Select(x=>x.Id).ToList();
        }

        public async Task<List<ProductDto>> GetProducts(Pagination pagination)
        {

var productPriceIdList=getProductIdsFilteredByPrice(pMax:0);
            var query=context.Products.AsQueryable();
            query = query.Include(x=>x.Discounts).AsQueryable();
query = query.Where(x=>productPriceIdList.Contains(x.Id));

            return await PagedList<ProductDto>.CreateAsync(
                query.ProjectTo<ProductDto>(mapper.ConfigurationProvider).AsNoTracking()
                ,pagination.Page,pagination.ItemsPerPage);
        }
        
        public async Task<Product> UpdateProduct(Product product)
        {
            var p = await  context.Products.FirstOrDefaultAsync(x=>x.Id == product.Id);
            if(!string.IsNullOrEmpty(product.Code)) p.Code=product.Code;
            p.Name=product.Name;
            p.CategoryId=product.CategoryId;
            p.Price=product.Price;
            p.Description=product.Description;
            p.Temporary=false;
            p.Deleted=p.Deleted;
            p.ModDate=System.DateTime.UtcNow;
            return p;
        }

        public async Task<PagedList<ProductBasicDto>> GetProductsManagment(string code, int? categoryId, Pagination pagination)
        {
            var query=context.Products
            .Where(x=>!x.Deleted && !x.Temporary).AsQueryable();
            if(!string.IsNullOrEmpty(code))query=query.Where(x=>x.Code.ToUpper().Contains(code.ToUpper())).AsQueryable();
            if(categoryId.HasValue)query=query.Where(x=>x.CategoryId == categoryId.Value).AsQueryable();


            return await PagedList<ProductBasicDto>.CreateAsync(
                query.ProjectTo<ProductBasicDto>(mapper.ConfigurationProvider).AsNoTracking()
                ,pagination.Page,pagination.ItemsPerPage);
        }

        public async void DeleteProduct(int productId)
        {
            var productToDelete= await context.Products.FirstOrDefaultAsync(x=>x.Id==productId);
            productToDelete.Deleted=true;
        }

        public async void RemoveTemporaryProducts()
        {
            var productsToRemove = await context.Products
            .Where(x=>x.Temporary && x.CreateDate<DateTime.UtcNow.AddDays(-7))
            .ToListAsync();
            context.Products.RemoveRange(productsToRemove);
        }
    }
}