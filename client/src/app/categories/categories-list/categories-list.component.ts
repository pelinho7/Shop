import { Component, ComponentFactoryResolver, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccordionPanelComponent } from 'ngx-bootstrap/accordion';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Category } from 'src/app/_models/category';
import { AttributeService } from 'src/app/_services/attribute.service';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { UpsertCategoryComponent } from '../upsert-category/upsert-category.component';

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
    ,private attributeService:AttributeService
    ,public mobileNavbarHelpersService:MobileNavbarHelpersService) { }

  ngOnInit(): void {
  }

  addNewCategorie(){
    this.upsertCategorieModal();
  }

  upsertCategorieModal() {
    this.attributeService.getAllAttributes().subscribe((attributes:any[])=>{
      const initialState: ModalOptions = {
        initialState: {
          category:new Category(),
          attributes:attributes
        },
        class:'modal-lg'
      };
      this.bsModalRef = this.modalService.show(UpsertCategoryComponent,initialState);
      this.bsModalRef.content.closeBtnName = 'Close'
    })

;
    
    // this.bsModalRef.onHidden.subscribe((reason: string | any) => {

    //   if(this.bsModalRef.content.saved){
    //     this.getAttributes();
    //   }
    // })
  }

  wiget:string='';
  add(){
    // // Select the table element
    // var parent = document.getElementById("asdf");
    // var a = parent.querySelector('.panel-body.card-block.card-body');


    // // Add a new row to the table using the correct activityNumber
    //   a.innerHTML += '<accordion-group heading="test">dsad</accordion-group>';

      // this.wiget='<accordion-group heading="test">dsad</accordion-group>';

      let childComponent = this.componentFactoryResolver.resolveComponentFactory(AccordionPanelComponent);
      //var a=childComponent.create();
      console.log(childComponent)
    //this.componentRef = this.target.createComponent(childComponent);

  }
}
