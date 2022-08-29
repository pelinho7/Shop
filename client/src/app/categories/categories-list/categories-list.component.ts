import { Component, ComponentFactoryResolver, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccordionPanelComponent } from 'ngx-bootstrap/accordion';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { HistoryComponent } from 'src/app/history/history.component';
import { Category } from 'src/app/_models/category';
import { AttributeService } from 'src/app/_services/attribute.service';
import { CategoryService } from 'src/app/_services/category.service';
import { ConfirmService } from 'src/app/_services/confirm.service';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { UpsertCategoryComponent } from '../upsert-category/upsert-category.component';
import { History as DataHistory} from '../../_models/history';
import { BusyService } from 'src/app/_services/busy.service';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {

  bsModalRef?: BsModalRef;
  constructor(private componentFactoryResolver: ComponentFactoryResolver
    ,private activatedRoute: ActivatedRoute
    ,private modalService: BsModalService
    ,private router:Router
    ,public categoryService:CategoryService
    ,private attributeService:AttributeService
    ,public mobileNavbarHelpersService:MobileNavbarHelpersService
    ,private confirmService:ConfirmService
    ,private busyService:BusyService) { }

  ngOnInit(): void {
    this.getCategories();
  }

  add(id:number){
    console.log(id)
  }

  edit(id:number){
    console.log(id)
  }

  delete(id:number){
    this.confirmService.confirm('Confirm delete message', 'This cannot be undone. Selected category and its subcategories will be deleted').subscribe(result=>{

      if(result){
        this.categoryService.deleteCategory(id).subscribe(_=>{});
      }
    })
  }
  expandReduce(id:number){
    this.categoryService.expandControl(id);
  }

  showHistory(id:number){
    this.categoryService.getCategoryHistory(id).subscribe((history:DataHistory[])=>{
      console.log(history)
      const initialState: ModalOptions = {
        initialState: {
          title:'Category History',
          historyList:history
        },
        class:'modal-xl'
      };
      this.bsModalRef = this.modalService.show(HistoryComponent,initialState);
      this.bsModalRef.content.closeBtnName = 'Close';
    });
  }

  addNewCategory(parentId:number){
    var category=new Category();
    category.parentCategoryId=parentId;
    if(parentId){
      this.categoryService.getCategory(parentId).subscribe((parentCategory:Category)=>{
        category.parentCategoriesAttributes = [ ...parentCategory.categoryAttributes, ...parentCategory.parentCategoriesAttributes];
        //console.log(parentCategory)
        this.upsertCategoryModal(category);
      })
    }
    else{
      this.upsertCategoryModal(category);
    }
  }

  updateNewCategory(id:number){
    this.categoryService.getCategory(id).subscribe((category:Category)=>{
      this.upsertCategoryModal(category);
    })
  }

  getCategories(){
    this.busyService.busy('main-spinner');
    this.categoryService.getCategories().subscribe((category:any)=>{
      this.busyService.idle('main-spinner');
    })
  }

  upsertCategoryModal(category:Category) {
    this.attributeService.getAllAttributes().subscribe((attributes:any[])=>{
      const initialState: ModalOptions = {
        initialState: {
          category:category,
          attributes:attributes
        },
        class:'modal-lg'
      };
      this.bsModalRef = this.modalService.show(UpsertCategoryComponent,initialState);
      this.bsModalRef.content.closeBtnName = 'Close'
    })
  }
}
