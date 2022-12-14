import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Opinion } from 'src/app/_models/opinion';
import { OpinionLike } from 'src/app/_models/opinionLike';
import { AccountService } from 'src/app/_services/account.service';
import { OpinionLikeService } from 'src/app/_services/opinion-like.service';
import { OpinionService } from 'src/app/_services/opinion.service';
import { UpsertProductOpinionComponent } from '../upsert-product-opinion/upsert-product-opinion.component';

@Component({
  selector: 'app-product-opinion',
  templateUrl: './product-opinion.component.html',
  styleUrls: ['./product-opinion.component.css']
})
export class ProductOpinionComponent implements OnInit {
  @Input() opinion:Opinion;
  bsModalRef:BsModalRef;
  loaded:boolean=false;
  constructor(public accountService:AccountService
    ,private modalService:BsModalService
    ,public opinionService:OpinionService
    ,private router:Router
    ,private opinionLikeService:OpinionLikeService) { }

  ngOnInit(): void {
  }

  edit(opinion:Opinion){
    var result = this.accountService.redirectIfTokenExpired();
    if(!result){
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
  
        }
      });
    }
  }

  remove(opinionId:number){
    this.opinionService.deleteOpinion(opinionId).subscribe(()=>{
      this.opinionService.getOpinions(this.opinion.productId,true).subscribe(_=>{})
    })
  }

  like(opinionId:number){
    if(this.opinion.currentUserOpinionLike == null){
      var opinionLike=new OpinionLike();
      opinionLike.opinionId=opinionId;
      this.opinionLikeService.insertOpinionLike(opinionLike).subscribe((opinionLike:OpinionLike)=>{
        this.opinion.currentUserOpinionLike=opinionLike;
        this.opinion.opinionLikesNumber++;
      })
    }
    else{
      this.opinionLikeService.deleteOpinionLike(this.opinion.currentUserOpinionLike.id).subscribe(()=>{
        this.opinion.currentUserOpinionLike=null;
        this.opinion.opinionLikesNumber--;
      })
    }
  }
}
