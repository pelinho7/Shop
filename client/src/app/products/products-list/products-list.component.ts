import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { DynamicControl } from '../../_models/dynamicControl';
import { Product } from '../../_models/product';
import { ProductService } from '../../_services/product.service';
import { FormsModule, NgForm } from '@angular/forms';
import { FilterAttribute } from '../../_models/filterAttribute';
import { Pagination } from 'src/app/_models/pagination';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css','./../../shared/mobile-sidenav.css']
})
export class ProductsListComponent implements OnInit {
  products:Product[];
  filterAttributes:FilterAttribute[];
  pagination:Pagination;
  paginationPanelStyles = new Map<string, string>();
  @ViewChild('editForm') editForm:NgForm;


  constructor(private productService:ProductService
    ,public resizeWindowWatcherService:ResizeWindowWatcherService) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  openMobileFilter(){
    var nav=(document.querySelector('#filter-products-panel') as HTMLElement);
    nav.style.width = '100%';
    nav.style.transition= '0.5s'

    var topNav=(document.querySelector('#top-navbar') as HTMLElement);
    topNav.style.zIndex='-1';
  }

  // closeNav(){
  //   (document.querySelector('#side-navbar') as HTMLElement).style.width = '0%';
  // }


  loadProducts(){
    let dynamicControls:DynamicControl[]=[];
    if(this.filterAttributes)
      this.filterAttributes.map(x=>x.dynamicControls).forEach(x=>dynamicControls= [...dynamicControls, ...x]);

    this.productService.getProducts(dynamicControls).subscribe(results=>{
      this.products=results.products;
      this.filterAttributes=results.filterAttributes;
      this.pagination=results.pagination;
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

pageChanged(event:any){
  // this.userParams.pageNumber=event.page;
  // this.memberService.setUserParams(this.userParams);
  // this.loadMembers();
}


}


