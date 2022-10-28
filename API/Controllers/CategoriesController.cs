using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Helpers;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using API.DBAccess.Interfaces;
using AutoMapper;
using API.Services.Interfaces;
using API.DBAccess;
using Microsoft.AspNetCore.Http;
using API.DBAccess.Entities;

namespace API.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly ILogger<CategoriesController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICreateHistoryService createHistoryService;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper
        , ILogger<CategoriesController> logger, ICreateHistoryService createHistoryService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
            this.createHistoryService = createHistoryService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryTreeItemDto>>> GetCategories()
        {
            
            var categories = await unitOfWork.CategoryRepository.GetCategories();
            var c=categories.Select(x=>mapper.Map<CategoryTreeItemDto>(x)).ToList();
            c=c.OrderBy(x=>x.ParentCategoryId).ToList();

            var categoryTree=buildCategoryTree(c).ToList();

            return Ok(categoryTree);
        }

        [NonAction]
        private  IList<CategoryTreeItemDto> buildCategoryTree(IEnumerable<CategoryTreeItemDto> source)
        {
            var groups = source.GroupBy(i => i.ParentCategoryId);

            var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();
            roots.ForEach(x=>x.Visible=true);
            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                    addSubcategories(roots[i], dict);
            }

            return roots;
        }
        [NonAction]
        private void addSubcategories(CategoryTreeItemDto node, IDictionary<int, List<CategoryTreeItemDto>> source)
        {
            if (source.ContainsKey(node.Id))
            {
                node.SubCategories = source[node.Id];
                node.SubCategories.ForEach(x=>x.TreeLevel=node.TreeLevel+1);
                for (int i = 0; i < node.SubCategories.Count; i++)
                    addSubcategories(node.SubCategories[i], source);
            }
            else
            {
                node.SubCategories = new List<CategoryTreeItemDto>();
            }
        }

        [HttpPost("upsert-category")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<CategoryDto>> UpsertCategory(CategoryDto categoryDto)
        {
            if(categoryDto==null)
                return BadRequest();

            var category = mapper.Map<Category>(categoryDto);
            // logger.LogError(System.Text.Json.JsonSerializer.Serialize(categoryDto));
            // throw new Exception("aa");
            using (var transaction = await unitOfWork.BeginTransaction())
            {
                try
                {
                    //split categoryattributes data form main category
                    List<CategoryAttribute> categoryAttributes=new List<CategoryAttribute>();
                    if(categoryDto.CategoryAttributes!=null){
                        categoryAttributes=categoryDto.CategoryAttributes.Select(x=>mapper.Map<CategoryAttribute>(x)).ToList();
                    }

                    category.CategoryAttributes.Clear();

                    DateTime modDate=DateTime.UtcNow;
                    category.ModDate=modDate;
                    bool savingResult;
                    bool creatingMode=true;
                    if(category.Id == 0){
                        unitOfWork.CategoryRepository.AddCategory(category);
                    }
                    else{
                        creatingMode=false;
                        category = await unitOfWork.CategoryRepository.UpdateCategory(category);
                        // modDate=category.ModDate;
                        var prevCategoryAttributes = await unitOfWork.CategoryAttributeRepository.GetCategoryAttributes(category.Id);
                        var deletedCategoryAttributes = prevCategoryAttributes.Where(ca=>!categoryAttributes.Select(x=>x.Id).Contains(ca.Id)).ToList();
                        //delete category attributes in DB
                        deletedCategoryAttributes.ForEach(ca=>{
                            ca.Deleted=true;
                            ca.ModDate=modDate;
                            unitOfWork.CategoryAttributeRepository.UpdateCategoryAttribute(ca);
                            unitOfWork.CategoryAttributeHistoryRepository.AddCategoryAttributeHistory(ca);
                        });
                    }

                    savingResult = await unitOfWork.Complete();
                    if (!savingResult) throw new Exception();


                    unitOfWork.CategoryHistoryRepository.AddCategoryHistory(category);

                    foreach(var ca in categoryAttributes){
                        ca.ModDate=modDate;
                        ca.CategoryId=category.Id;

                        if(ca.Id==0){
                            unitOfWork.CategoryAttributeRepository.AddCategoryAttribute(ca);
                            savingResult = await unitOfWork.Complete();
                            if (!savingResult) {
                                throw new Exception();
                            }
                        }
                        else{
                            unitOfWork.CategoryAttributeRepository.UpdateCategoryAttribute(ca);
                        }
                        
                        var a=mapper.Map<CategoryAttribute,CategoryAttributeHistory>(ca);
                        logger.LogError(JsonSerializer.Serialize(a));
                        unitOfWork.CategoryAttributeHistoryRepository.AddCategoryAttributeHistory(ca);
                        savingResult = await unitOfWork.Complete();
                        if (!savingResult) throw new Exception();
                    }
    

                    if(category.ParentCategoryId.HasValue && creatingMode){
                        unitOfWork.CategoryLinkRepository.UpsertCategoryLinks(category);
                        savingResult = await unitOfWork.Complete();
                        if (!savingResult) throw new Exception();
                    }

                    //transaction.Rollback();
                    // logger.LogError("aaaaaaaaaa");
                    transaction.Commit();
                    //                     logger.LogError("bbbbbbbb");
                    categoryDto = mapper.Map<CategoryDto>(category);

                }
                catch (Exception e)
                {
                    logger.LogError("sss "+e.Message);
                    transaction.Rollback();
                    return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");
                }
            }

            return Ok(categoryDto);
        }

        [HttpGet("get-category/{categoryId:int}")]
        public async Task<ActionResult> GetCategory(int categoryId)
        {
            if(categoryId<=0)
                return BadRequest();


            var category = await unitOfWork.CategoryRepository.GetCategory(categoryId);
 
            if (category==null) return NotFound();
            var parentCategoriesAttributes = await unitOfWork.CategoryAttributeRepository.GetParentCategoriesAttributes(categoryId);
            category.ParentCategoriesAttributes=parentCategoriesAttributes;

            var categoryDto = mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpDelete("delete-category/{categoryId:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            if(categoryId<=0)
                return BadRequest();

            using (var transaction = await unitOfWork.BeginTransaction())
            {
                try
                {
                    var category = await unitOfWork.CategoryRepository.GetCategory(categoryId);
                    if(category==null){
                        return NotFound();
                    }
                    List<int> categoriesToDeleted=new List<int>(){categoryId};
                    var subCategoriesList = await unitOfWork.CategoryLinkRepository.GetSubCategoriesIds(categoryId);
                    categoriesToDeleted.AddRange(subCategoriesList);

                    foreach(var catId in categoriesToDeleted){
                        unitOfWork.CategoryRepository.DeleteCategory(catId);
                    }

                    bool savingResult = await unitOfWork.Complete();
                    if (!savingResult) throw new Exception();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");
                }
            }
            return Ok();
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("check-code-not-taken")]
        public async Task<ActionResult<bool>> CheckCodeNotTaken(string code)
        {
            if (string.IsNullOrEmpty(code)) return true;

            var category = await unitOfWork.CategoryRepository.GetCategoryByCode(code);
            if (category != null)
            {
                return false;
            }

            return true;
        }

        [HttpGet("get-category-history")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<HistoryDto>>> GetCategoryHistory(int id,int timezone,string location)
        {
            var categoryHistory = await unitOfWork.CategoryHistoryRepository.GetCategoryHistoryByIdAsync(id);
            var groupedCategories=categoryHistory.GroupBy(x=>x.CategoryId).ToList();
            var historyCategoryList = createHistoryService.CreateHistory(groupedCategories,timezone,location);

            var categoryAttributesHistory = await unitOfWork.CategoryAttributeHistoryRepository.GetCategoryAttributeHistoryByIdAsync(id);
            var groupedCategoryAttributes=categoryAttributesHistory.GroupBy(x=>x.AttributeId).ToList();
            var historyCategoryAttributesList = createHistoryService.CreateHistory(groupedCategoryAttributes,timezone,location);
            //change object id to category id
            historyCategoryAttributesList.ForEach(x=>x.ObjectId=id);
       
            //merge category history and category attributes history base on modedate and type of modyfication
            for(int i=historyCategoryAttributesList.Count-1;i>=0;i--){
                var catHistoryPosition = historyCategoryList
                .FirstOrDefault(x=>x.Moddate ==historyCategoryAttributesList[i].Moddate && x.Type == historyCategoryAttributesList[i].Type);
                if(catHistoryPosition!=null){
                    catHistoryPosition.PropertiesHistory.AddRange(historyCategoryAttributesList[i].PropertiesHistory);
                    historyCategoryAttributesList.RemoveAt(i);
                }
            }
            //add rest of category attributes history whitch not paired with category history
            historyCategoryList.AddRange(historyCategoryAttributesList);
            historyCategoryList = historyCategoryList.OrderByDescending(x=>x.Moddate).ToList();

            return Ok(historyCategoryList);
        }
    }
}
