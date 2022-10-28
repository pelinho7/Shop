import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Opinion } from 'src/app/_models/opinion';
import { OpinionService } from 'src/app/_services/opinion.service';

@Component({
  selector: 'app-upsert-product-opinion',
  templateUrl: './upsert-product-opinion.component.html',
  styleUrls: ['./upsert-product-opinion.component.css']
})
export class UpsertProductOpinionComponent implements OnInit {

  opinionForm:FormGroup;
  opinion:Opinion;
  title:string;
  editMode:boolean=false;
  saved:boolean=false;
  constructor(public bsModalRef: BsModalRef
    ,private fb:FormBuilder
    ,private toastr:ToastrService
    ,private opinionService:OpinionService) { }

  ngOnInit(): void {
    //this.opinion=new Opinion();
    if(this.opinion.id == 0){
      this.title='New opinion';
    }
    else{
      this.title='Edit opinion';
      this.editMode=true;
    }
    this.opinionForm=this.fb.group({
      id:[this.opinion.id,Validators.required],
      rating:[this.opinion.rating,Validators.required],
      title:[this.opinion.title,[Validators.required,Validators.maxLength(30)]],
      content:[this.opinion.content,[Validators.required,Validators.maxLength(30)]],
      deleted:[this.opinion.deleted],
      productId:[this.opinion.productId],
    })
  }

  save(){
    this.opinionService.upsertOpinion(this.opinionForm.value).subscribe((opinion:any)=>{
      if(this.editMode){
        this.toastr.info('Opinion edited')
      }
      else{
        this.toastr.info('Opinion added')
      }
      this.saved=true;
      this.bsModalRef.hide();
    })
  }
}
