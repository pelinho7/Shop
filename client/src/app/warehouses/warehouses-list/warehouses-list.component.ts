import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { AttributesFiltration } from 'src/app/_models/attributesFiltration';
import { Pagination } from 'src/app/_models/pagination';
import { AttributeService } from 'src/app/_services/attribute.service';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { WarehouseService } from 'src/app/_services/warehouse.service';

@Component({
  selector: 'app-warehouses-list',
  templateUrl: './warehouses-list.component.html',
  styleUrls: ['./warehouses-list.component.css']
})
export class WarehousesListComponent implements OnInit {

  loaded=false;
  bsModalRef?: BsModalRef;
  attributesFiltrationForm:FormGroup;
  pagination:Pagination;
  attributesFiltrationParams: AttributesFiltration;

  constructor(public warehouseService:WarehouseService,private fb:FormBuilder
    ,private activatedRoute: ActivatedRoute
    ,private modalService: BsModalService
    ,private toastr:ToastrService,private router:Router
    ,public mobileNavbarHelpersService:MobileNavbarHelpersService) { }

  ngOnInit(): void {
  //   this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  //   this.attributesFiltrationParams=new AttributesFiltration();
  //   this.activatedRoute.queryParams.subscribe(params => {
  //     this.attributesFiltrationParams=new AttributesFiltration();
  //     this.attributesFiltrationParams.castJsonToClass((params as AttributesFiltration));

  //     this.attributesFiltrationForm=this.fb.group({
  //       code:[this.attributesFiltrationParams.code,Validators.maxLength],
  //       type:[this.attributesFiltrationParams.type],
  //       itemsPerPage:[this.attributesFiltrationParams.itemsPerPage],
  //     })
  // });

  //   this.getAttributes();
  }


  getAttributes(){
    this.warehouseService.getAttributes(this.attributesFiltrationParams).subscribe((pagination:Pagination)=>{
      this.pagination=pagination;
      this.router.navigateByUrl('/attributes'+this.warehouseService.requestParameters);
      this.loaded=true;
    })
  }

  pageChanged(event:any){
    if(!this.loaded)return;
    this.attributesFiltrationParams.page=event.page;
    console.log(event)
    this.getAttributes();
  }

  filter(){
    this.attributesFiltrationParams=this.attributesFiltrationForm.value;
    this.attributesFiltrationParams.page=1;
    this.getAttributes();
  }

  edit(id:number){
    // var attribute = this.attributeService.attributesPage.find(x=>x.id==id);
    // this.upsertAttributeModal(attribute);
  }

  onDelete(id:number){
    // var attribute = this.attributeService.attributesPage.find(x=>x.id==id);
    // this.attributeService.deleteAttribute(id).subscribe(_=>{
    //   this.getAttributes();
    // })
  }

  upsertAttributeModal(attribute:any) {
    // const initialState: ModalOptions = {
    //   initialState: {
    //     attribute:attribute,
    //   },
    //   class:'modal-lg'
    // };
    // this.bsModalRef = this.modalService.show(UpsertAttributeComponent,initialState);
    // this.bsModalRef.content.closeBtnName = 'Close';
    // console.log(this.bsModalRef.content)
    // this.bsModalRef.onHidden.subscribe((reason: string | any) => {

    //   if(this.bsModalRef.content.saved){
    //     this.getAttributes();
    //   }
    // })
  }

  addNewWarehouse(){
    //this.upsertAttributeModal(new Attribute())
  }

  onEdit(attribute:any){
    //this.upsertAttributeModal(attribute)
  }
}
