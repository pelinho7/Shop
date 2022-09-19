import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ProductManagmentService } from 'src/app/_services/product-managment.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product-images-picker',
  templateUrl: './product-images-picker.component.html',
  styleUrls: ['./product-images-picker.component.css']
})
export class ProductImagesPickerComponent implements OnInit {

  public selectedUrl:string='';
  constructor(public bsModalRef: BsModalRef
    ,public productService:ProductManagmentService) { }

  ngOnInit(): void {
  }

  selected(url:string){
    this.selectedUrl=url;
    this.bsModalRef.hide();
  }
}
