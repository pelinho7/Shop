import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { AttributeCodeNotTaken } from 'src/app/validators/attribute-code-not-taken.validator';
import { Attribute } from 'src/app/_models/attribute';
import { AttributeService } from 'src/app/_services/attribute.service';

@Component({
  selector: 'app-upsert-attribute',
  templateUrl: './upsert-attribute.component.html',
  styleUrls: ['./upsert-attribute.component.css']
})
export class UpsertAttributeComponent implements OnInit {

  title?: string="New attribute";
  attribute:Attribute
  attributeForm:FormGroup;
  selectedType:number;
  filtrationModesArray = new Map<number, string>();
  filtrationModeVisibile:boolean=false;
  editMode:boolean=false;
  saved:boolean=false;
 
  constructor(public bsModalRef: BsModalRef,private fb:FormBuilder
    ,public attributeService:AttributeService
    ,private toastr:ToastrService) {}

  ngOnInit(): void {
    if(this.attribute.id>0){
      this.title="Edit attribute";
      this.title="Edit "+this.attribute.code+" attribute";
      this.editMode=true;
    }
    this.attributeForm=this.fb.group({
      id:[this.attribute.id,Validators.required],
      code:[{value: this.attribute.code, disabled: this.editMode},[Validators.required,Validators.maxLength(30)]],
      label:[this.attribute.label,[Validators.required,Validators.maxLength(60)]],
      type:[{value: this.attribute.type, disabled: this.editMode},Validators.required],
      decimalPlaces:[this.attribute.decimalPlaces,Validators.required],
      filtrationMode:[this.attribute.filtrationMode,Validators.required],
      deleted:[this.attribute.deleted],
    })
    if(!this.editMode){
      this.attributeForm.controls['code'].setAsyncValidators(AttributeCodeNotTaken.createValidator(this.attributeService));
    }
    else{
      this.typeChanged(this.attribute.type,this.attribute.filtrationMode);
    }
    this.attributeForm.controls['type'].valueChanges.subscribe((type:number)=>{
      this.typeChanged(type);
    })
  }

  typeChanged(type:number,filtrationMode:number=null){
    this.selectedType=type;
    //reload decimalPlaces
    this.attributeForm.controls['decimalPlaces'].setValue(0);
    //get filtration mode arrray to current type
    var filtrationModesForAttributeType=this.attributeService.filtrationModesAttributeTypesMap.filter(x=>x[1]==type).map(x=>x[0])//.find(x=>x.find(x=>x==type)).;
    this.filtrationModesArray.clear();
    filtrationModesForAttributeType.map(x=>this.filtrationModesArray.set(x,this.attributeService.filtrationModes.get(x)));
    let keys =[ ...this.filtrationModesArray.keys() ];
    if(keys.length==1){
      let keys =[ ...this.filtrationModesArray.keys() ];
      this.attributeForm.controls['filtrationMode'].setValue(keys[0]);
      this.filtrationModeVisibile=false;
    }
    else if(keys.length==0){
      this.filtrationModeVisibile=false;
    }
    else{
      this.filtrationModesArray.set(null,"Filtration mode")
      this.attributeForm.controls['filtrationMode'].setValue(filtrationMode);
      this.filtrationModeVisibile=true;
    }
  }

  save(){
    this.attributeService.upsertAttribute(this.attributeForm.value).subscribe((attribute:any)=>{
      if(this.editMode){
        this.toastr.info('Attribute edited')
      }
      else{
        this.toastr.info('Attribute added')
      }
      this.saved=true;
      this.bsModalRef.hide();
    })
  }

}
