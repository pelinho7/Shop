import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { WarehouseCodeNotTaken } from 'src/app/validators/warehouse-code-not-taken.validator';
import { Warehouse } from 'src/app/_models/warehouse';
import { WarehouseService } from 'src/app/_services/warehouse.service';

@Component({
  selector: 'app-upsert-warehouse',
  templateUrl: './upsert-warehouse.component.html',
  styleUrls: ['./upsert-warehouse.component.css']
})
export class UpsertWarehouseComponent implements OnInit {

  title?: string="New warehouse";
  warehouse:Warehouse
  warehouseForm:FormGroup;
  editMode:boolean=false;
  saved:boolean=false;
 
  constructor(public bsModalRef: BsModalRef,private fb:FormBuilder
    ,public warehouseService:WarehouseService
    ,private toastr:ToastrService) {}

  ngOnInit(): void {
    if(this.warehouse.id>0){
      this.title="Edit warehouse";
      this.title="Edit "+this.warehouse.code+" warehouse";
      this.editMode=true;
    }
    this.warehouseForm=this.fb.group({
      id:[this.warehouse.id,Validators.required],
      code:[{value: this.warehouse.code, disabled: this.editMode},[Validators.required,Validators.maxLength(30)]],
      label:[this.warehouse.label,[Validators.required,Validators.maxLength(60)]],
      deleted:[this.warehouse.deleted],
    })
    if(!this.editMode){
      this.warehouseForm.controls['code'].setAsyncValidators(WarehouseCodeNotTaken.createValidator(this.warehouseService));
    }
  }


  save(){
    this.warehouseService.upsertWarehouse(this.warehouseForm.value).subscribe((warehouse:any)=>{
      if(this.editMode){
        this.toastr.info('Warehouse edited')
      }
      else{
        this.toastr.info('Warehouse added')
      }
      this.saved=true;
      this.bsModalRef.hide();
    })
  }

}
