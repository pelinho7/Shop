import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { Opinion } from 'src/app/_models/opinion';
import { Product } from 'src/app/_models/product';
import { ProductListItem } from 'src/app/_models/productListItem';
import { AccountService } from 'src/app/_services/account.service';
import { ProductService } from 'src/app/_services/product.service';
import { ProductOpinionsListComponent } from '../opinions/product-opinions-list/product-opinions-list.component';
import { UpsertProductOpinionComponent } from '../opinions/upsert-product-opinion/upsert-product-opinion.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @HostListener('window:scroll', ['$event']) onScrollEvent($event:any){
    const winScrollTop = window.pageYOffset 
    || document.documentElement.scrollTop 
    || document.body.scrollTop || 0;

    var shopPanel =document.getElementById('shop-panel');
    var shopPanelHeight = shopPanel?.getBoundingClientRect().height;
    //compensate of shop panel height in offset calculation
    this.offset=Math.max(0,winScrollTop-shopPanelHeight)
  }

  offset:number=0;
  productCode:string='';
  product:ProductListItem;
  bsModalRef:BsModalRef;
  @ViewChild('opinionsList') opinionsList:ProductOpinionsListComponent;
  constructor(private productService:ProductService
    ,private router:Router
    ,private accountService:AccountService
    ,private modalService:BsModalService) { 
      this.productCode=this.router.url.substring(this.router.url.lastIndexOf('/')+1);
  }

  ngOnInit(): void {
    this.productService.getProductFullData(this.productCode).subscribe(product=>{
      this.product=product;
      console.log(product)
    })
  }

  selectedTabChange(event:any){
    if(event.index == 2){
      this.opinionsList.loadOpinions();
    }
  }
}
