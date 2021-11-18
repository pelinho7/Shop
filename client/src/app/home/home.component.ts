import { Component, OnInit, ViewChild } from '@angular/core';
import { DynamicControl } from '../_models/DynamicControl';
import { Product } from '../_models/Product';
import { ProductService } from '../_services/product.service';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  products:Product[];
  dynamicControls:DynamicControl[];
  @ViewChild('editForm') editForm:NgForm;

  constructor(private productService:ProductService) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(){
    this.productService.getProducts(this.dynamicControls).subscribe(products=>{
      this.products=products;
      this.dynamicControls=this.productService.getDynamicControls();
    })
  }

  filterProducts(){
    this.loadProducts();
  }

}
