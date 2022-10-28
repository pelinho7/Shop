import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, ReplaySubject } from 'rxjs';
import { map,take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { RegisterComponent } from '../account/register/register.component';
import { getTimezone, getUsersLocale } from '../_helpers/historyHelpers';
import { Category } from '../_models/category';
import { CategoryTreeItem } from '../_models/categoryTreeItem';
import { Registration } from '../_models/registration';
import { History as DataHistory } from '../_models/history';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseUrl=environment.apiUrl;
  private categoriesTreeSource=new ReplaySubject<CategoryTreeItem[]>(1);
  categoriesTree$=this.categoriesTreeSource.asObservable();
  constructor(private http:HttpClient) { 
  }

  checkCodeNotTaken(code:string){
    return this.http.get<boolean>(this.baseUrl+'categories/check-code-not-taken?code='+code).pipe(
      map((result:boolean)=>{
        return result;
      })
    )
  }

  upsertCategory(model:Category){
    let editMode:boolean=model.id>0;
    return this.http.post<any>(this.baseUrl+'categories/upsert-category',model).pipe(
      map((category:any)=>{
        let categoryTree:CategoryTreeItem[];
        this.categoriesTree$.pipe(take(1)).subscribe(x=>categoryTree=x);
        if(categoryTree){
          if(editMode){
            categoryTree = this.updateCategoryInTree(category,categoryTree);
          }
          else{
            categoryTree = this.addCategoryToTree(category,categoryTree);
          }
          this.categoriesTreeSource.next(categoryTree);
        }

          return category;
        })
    )
  }

  deleteCategory(id:number){
    return this.http.delete(this.baseUrl+'categories/delete-category/'+id).pipe(
      map(()=>{
        let categoryTree:CategoryTreeItem[];
        this.categoriesTree$.pipe(take(1)).subscribe(x=>categoryTree=x);
        if(categoryTree){
          categoryTree = this.deleteCategoryInTree(id,categoryTree);
          this.categoriesTreeSource.next(categoryTree);
        }

       return;
      })
    )
  }

  getCategory(id:number){
    return this.http.get<Category>(this.baseUrl+'categories/get-category/'+id).pipe(
      map(((category:any)=>{
        //console.log(category)
       return category;
      })
    ))
  }

  getCategories(){
    let currentCategories:CategoryTreeItem[];
    this.categoriesTree$.pipe(take(1)).subscribe(c=>currentCategories=c);
    if (currentCategories === undefined) {
      return this.http.get<CategoryTreeItem[]>(this.baseUrl+'categories').pipe(
        map(((categories:any)=>{
          this.categoriesTreeSource.next(categories);
         return categories;
        })
      ))
    }
    else{
      return of(currentCategories);
    }
  }

  categoryTree2Map(categories:CategoryTreeItem[],categoryMap : Map<number, string>){
    categories.forEach(categoryItem => {
      var tab:string=""
      for (let i = 0; i < categoryItem.treeLevel; i++) {
        tab+="\xA0\xA0";
      }
      categoryMap.set(categoryItem.id,tab+categoryItem.code);
      if(categoryItem.subCategories!=null){
        this.categoryTree2Map(categoryItem.subCategories,categoryMap)
      }
    });
    return categoryMap;
  }

  getCategoryTree2Array(categories:CategoryTreeItem[],array:CategoryTreeItem[]){
    categories.forEach(categoryItem => {
      if(categoryItem.subCategories!=null){
        this.getCategoryTree2Array(categoryItem.subCategories,array)
      }
      array.push(categoryItem)
    });
    return array;
  }

  expandControl(parentId:number){
    let categoryTree:CategoryTreeItem[];
    this.categoriesTree$.pipe(take(1)).subscribe(x=>categoryTree=x);
    categoryTree=this.changeSubcategoriesVisibility(parentId,categoryTree);
    this.categoriesTreeSource.next(categoryTree);
  }

  changeSubcategoriesVisibility(id:number,categoryTree:CategoryTreeItem[]){
    var category = categoryTree.find(x=>x.id == id);
    if(!category){
      categoryTree.forEach(category => {
        this.changeSubcategoriesVisibility(id,category.subCategories);
      });
    }
    else{
      category.subCategories.forEach(c => {
        c.visible=!c.visible;
      });
    }
    return categoryTree;
  }

  addCategoryToTree(category:Category,categoryTree:CategoryTreeItem[]){
    //var category = categoryTree.find(x=>x.id == id);
    if(!category.parentCategoryId || category.parentCategoryId==0){
      var newCategoryTreeItem:CategoryTreeItem=new CategoryTreeItem();
      newCategoryTreeItem.categoryToCategoryTreeItem(category,0);
      categoryTree.push(newCategoryTreeItem);
    }
    else{
      var parentCategory = categoryTree.find(x=>x.id == category.parentCategoryId);
      if(parentCategory){
        var newCategoryTreeItem:CategoryTreeItem=new CategoryTreeItem();
        newCategoryTreeItem.categoryToCategoryTreeItem(category,parentCategory.treeLevel+1);
        parentCategory.subCategories.push(newCategoryTreeItem);
      }
      else{
        categoryTree.forEach(categoryTreeItem => {
          this.addCategoryToTree(category,categoryTreeItem.subCategories);
        });
      }
    }
    return categoryTree;
  }

  updateCategoryInTree(categoryToUpdate:Category,categoryTree:CategoryTreeItem[]){
    var category = categoryTree.find(x=>x.id == categoryToUpdate.id);
    if(!category){
      categoryTree.forEach(c => {
        this.updateCategoryInTree(categoryToUpdate,c.subCategories);
      });
    }
    else{
      category.code=categoryToUpdate.code;
      category.label=categoryToUpdate.label;
    }
    return categoryTree;
  }

  deleteCategoryInTree(id:number,categoryTree:CategoryTreeItem[]){
    var category = categoryTree.find(x=>x.id == id);
    if(category){
      categoryTree.splice(categoryTree.indexOf(category), 1);
    }
    else{
      categoryTree.forEach(c => {
        this.deleteCategoryInTree(id,c.subCategories);
      });
    }
    return categoryTree;
  }

  getCategoryHistory(id:number){
    var timezone=getTimezone();
    var location=getUsersLocale();
  
    return this.http.get<DataHistory[]>(this.baseUrl+'categories/get-category-history?id='+id+'&timezone='+timezone+'&location='+location).pipe(
      map((historyList:DataHistory[])=>{
        return historyList;
      })
    )
  }
}
