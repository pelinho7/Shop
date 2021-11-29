import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
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


  //   $(window).scroll(function() {
  //     var winScrollTop = $(window).scrollTop();
  //     var winHeight = $(window).height();
  //     var floaterHeight = $('#floater').outerHeight(true);
  //     //true so the function takes margins into account
  //     var fromBottom = 20;
  
  //     var top = winScrollTop + winHeight - floaterHeight - fromBottom;
  //     $('#floater').css({'top': top + 'px'});
  // });

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

  onFilter(event:any) {
    console.log(this.filterAttributes)
    //console.log(filterAttributes);
}
}
function onScrollEvent($event: any) {
  throw new Error('Function not implemented.');
}

