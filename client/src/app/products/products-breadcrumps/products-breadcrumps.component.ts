import { Component, OnInit } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { CategoryTreeItem } from 'src/app/_models/categoryTreeItem';
import { CategoryService } from 'src/app/_services/category.service';
import { ProductsListComponent } from '../products-list/products-list.component';

@Component({
  selector: 'app-products-breadcrumps',
  templateUrl: './products-breadcrumps.component.html',
  styleUrls: ['./products-breadcrumps.component.css']
})
export class ProductsBreadcrumpsComponent implements OnInit {

  //public breadcrumpsCategories:CategoryTreeItem[]=[];
  private breadcrumpsCategoriesSource=new ReplaySubject<CategoryTreeItem[]>(1);
  breadcrumpsCategories$=this.breadcrumpsCategoriesSource.asObservable();
  currentCategoryCode:string='sss'
  constructor(private categoryService:CategoryService
    ,private productsListComponent:ProductsListComponent) { }

  ngOnInit(): void {
    this.currentCategoryCode = this.productsListComponent.category
    this.categoryService.getCategories().subscribe(x=>{

      var tempCategoriesArray:CategoryTreeItem[]=[];
      var categoriesArray = this.categoryService.getCategoryTree2Array(x,tempCategoriesArray);
      var currentCategory=categoriesArray.find(x=>x.code == this.currentCategoryCode);
      var breadcrumpsCategories:CategoryTreeItem[]=[]
      var parentCatId=currentCategory.parentCategoryId;

      while(true){
        if(parentCatId == null){
          break;
        }
        var parentCategory=categoriesArray.find(x=>x.id == parentCatId);
        parentCatId=parentCategory.parentCategoryId;
        breadcrumpsCategories.splice(0, 0, parentCategory);
      }
      this.breadcrumpsCategoriesSource.next(breadcrumpsCategories)
    })
  }

}
