import { Component, OnInit, ViewChild } from '@angular/core';
import { DynamicControl } from '../../_models/dynamicControl';
import { Product } from '../../_models/product';
import { ProductService } from '../../_services/product.service';
import { FormsModule, NgForm } from '@angular/forms';
import { FilterAttribute } from '../../_models/filterAttribute';
import { map } from "rxjs/operators";

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  products:Product[];
  filterAttributes:FilterAttribute[];
  //dynamicControls:DynamicControl[];
  @ViewChild('editForm') editForm:NgForm;

  constructor(private productService:ProductService) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(){
    let dynamicControls:DynamicControl[]=[];
    if(this.filterAttributes)
      this.filterAttributes.map(x=>x.dynamicControls).forEach(x=>dynamicControls= [...dynamicControls, ...x]);

    this.productService.getProducts(dynamicControls).subscribe(results=>{
      this.products=results.products;
      this.filterAttributes=results.filterAttributes;
    })
  }

  filterProducts(){
    console.log(this.filterAttributes);
    this.loadProducts();
  }

}
