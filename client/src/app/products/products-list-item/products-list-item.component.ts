import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReplaySubject } from 'rxjs';
import { Product } from 'src/app/_models/product';
import { ProductListItem } from 'src/app/_models/productListItem';
import { ProductTextAttribute } from 'src/app/_models/productTextAttribute';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-products-list-item',
  templateUrl: './products-list-item.component.html',
  styleUrls: ['./products-list-item.component.css']
})
export class ProductsListItemComponent implements OnInit {
  @Input() product:ProductListItem;
  public parameters: ReplaySubject<ProductTextAttribute[]> = new ReplaySubject<ProductTextAttribute[]>(1);

  constructor(private router:Router
    ,private productService:ProductService) { }

  ngOnInit(): void {
  }
  
  navigateToProduct(productCode:string){
    this.router.navigateByUrl('/product/'+productCode)
  }

  getProductAttributes(event:any){
    console.log(event.srcElement.classList)
    if(event.srcElement.classList.contains('show')){
      this.productService.getProductAllAttributes(this.product.categoryId,this.product.id).subscribe(params=>{
        event.srcElement.innerText='Hide parameters';
        event.srcElement.classList.remove('show');
        event.srcElement.classList.add('hide');
        this.parameters.next(params);
      })
    }
    else{
      event.srcElement.innerText='Show parameters';
      event.srcElement.classList.add('show');
      event.srcElement.classList.remove('hide');
      this.parameters.next([]);
    }
  }
}
