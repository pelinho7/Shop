import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Opinion } from 'src/app/_models/opinion';
import { AccountService } from 'src/app/_services/account.service';
import { OpinionService } from 'src/app/_services/opinion.service';
import { UpsertProductOpinionComponent } from '../upsert-product-opinion/upsert-product-opinion.component';

@Component({
  selector: 'app-product-opinions-list',
  templateUrl: './product-opinions-list.component.html',
  styleUrls: ['./product-opinions-list.component.css']
})
export class ProductOpinionsListComponent implements OnInit {

  offset:number=0;
  @Input() productId:number=0;
  bsModalRef:BsModalRef;
  loaded:boolean=false;
  opinionsSortingForm:FormGroup;
  constructor(public accountService:AccountService
    ,private modalService:BsModalService
    ,public opinionService:OpinionService
    ,private fb:FormBuilder) { }

  ngOnInit(): void {
    // this.opinionsSortingForm=this.fb.group({
    //   sorting:[0],
    // })
  }

  sortingTypeChanged(){
    //this.opinionService.setSortingType(this.opinionsSortingForm.value.sorting)
    this.opinionService.getOpinions(this.productId,true).subscribe(x=>{
      this.loaded=true;
    })
  }

  loadOpinions(){
    if(!this.loaded){
      this.opinionService.getOpinions(this.productId).subscribe(x=>{
        this.loaded=true;
      })
    }
  }

  showMore(){
    this.opinionService.getOpinions(this.productId).subscribe(_=>{})
  }

  upsertOpinion(opinionId:null){
    var opinion=new Opinion();
    opinion.productId=this.productId;
    const initialState: ModalOptions = {
      initialState: {
        opinion:opinion,
      },
      class:'modal-md'
    };
    this.bsModalRef = this.modalService.show(UpsertProductOpinionComponent,initialState);
    this.bsModalRef.content.closeBtnName = 'Close'
    this.bsModalRef.onHidden.subscribe(()=>{
      //change of image src
      if(this.bsModalRef.content.saved){
        this.opinionService.setSortingType(0);
        this.opinionService.getOpinions(this.productId,true).subscribe(_=>{})
      }
    });
  }
}
