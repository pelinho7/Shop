import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { AttributesFiltration } from 'src/app/_models/attributesFiltration';
import { Pagination } from 'src/app/_models/pagination';
import { Warehouse } from 'src/app/_models/warehouse';
import { WarehousesFiltration } from 'src/app/_models/warehousesFiltration';
import { AttributeService } from 'src/app/_services/attribute.service';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { WarehouseService } from 'src/app/_services/warehouse.service';
import { UpsertWarehouseComponent } from '../upsert-warehouse/upsert-warehouse.component';

@Component({
  selector: 'app-warehouses-list',
  templateUrl: './warehouses-list.component.html',
  styleUrls: ['./warehouses-list.component.css']
})
export class WarehousesListComponent implements OnInit {

  loaded=false;
  bsModalRef?: BsModalRef;
  warehousesFiltrationForm:FormGroup;
  pagination:Pagination;
  warehousesFiltrationParams: WarehousesFiltration;

  constructor(public warehouseService:WarehouseService,private fb:FormBuilder
    ,private activatedRoute: ActivatedRoute
    ,private modalService: BsModalService
    ,private toastr:ToastrService,private router:Router
    ,public mobileNavbarHelpersService:MobileNavbarHelpersService) { }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.warehousesFiltrationParams=new WarehousesFiltration();

    this.activatedRoute.queryParams.subscribe(params => {
      this.warehousesFiltrationParams=new WarehousesFiltration();
      this.warehousesFiltrationParams.castJsonToClass((params as WarehousesFiltration));

      this.warehousesFiltrationForm=this.fb.group({
        code:[this.warehousesFiltrationParams.code,Validators.maxLength],
        itemsPerPage:[this.warehousesFiltrationParams.itemsPerPage],
      })
  });

    this.getWarehouses();
  }


  getWarehouses(){
    this.warehouseService.getWarehouses(this.warehousesFiltrationParams).subscribe((pagination:Pagination)=>{
      this.pagination=pagination;
      this.router.navigateByUrl('/warehouses'+this.warehouseService.requestParameters);
      this.loaded=true;
    })
  }

  pageChanged(event:any){
    if(!this.loaded)return;
    this.warehousesFiltrationParams.page=event.page;
    console.log(event)
    this.getWarehouses();
  }

  filter(){
    this.warehousesFiltrationParams=this.warehousesFiltrationForm.value;
    this.warehousesFiltrationParams.page=1;
    this.getWarehouses();
  }

  edit(id:number){
    var warehouse = this.warehouseService.warehousesPage.find(x=>x.id==id);
    this.upsertWarehouseModal(warehouse);
  }

  onDelete(id:number){
    var warehouse = this.warehouseService.warehousesPage.find(x=>x.id==id);
    this.warehouseService.deleteWarehouse(id).subscribe(_=>{
      this.getWarehouses();
    })
  }

  upsertWarehouseModal(warehouse:any) {
    const initialState: ModalOptions = {
      initialState: {
        warehouse:warehouse,
      },
      class:'modal-lg'
    };
    this.bsModalRef = this.modalService.show(UpsertWarehouseComponent,initialState);
    this.bsModalRef.content.closeBtnName = 'Close';
    console.log(this.bsModalRef.content)
    this.bsModalRef.onHidden.subscribe((reason: string | any) => {

      if(this.bsModalRef.content.saved){
        this.getWarehouses();
      }
    })
  }

  addNewWarehouse(){
    this.upsertWarehouseModal(new Warehouse())
  }

  onEdit(warehouse:any){
    this.upsertWarehouseModal(warehouse)
  }
}
