import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { DynamicControl } from '../../_models/dynamicControl';
import { Product } from '../../_models/product';
import { ProductService } from '../../_services/product.service';
import { FormsModule, NgForm } from '@angular/forms';
import { FilterAttribute } from '../../_models/filterAttribute';
import { Pagination } from 'src/app/_models/pagination';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';
import { ActivatedRoute, Router } from '@angular/router';

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
    ,public resizeWindowWatcherService:ResizeWindowWatcherService,private route: Router) { }

  ngOnInit(): void {
    var urlParam='';
    if(this.route.url.includes('/') && this.route.url.lastIndexOf('/')!=0){
      urlParam=this.route.url.substring(this.route.url.lastIndexOf('/'));
    }
    else if(this.route.url.includes('?')){
      urlParam=this.route.url.substring(this.route.url.indexOf('?'));
    }
    console.log('1111111111 '+urlParam)
      this.loadProducts(urlParam);
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


  loadProducts(initPath:string=''){
    let dynamicControls:DynamicControl[]=[];
    if(this.filterAttributes)
      this.filterAttributes.map(x=>x.dynamicControls).forEach(x=>dynamicControls= [...dynamicControls, ...x]);
      
    console.log(dynamicControls);
    this.productService.getProducts(dynamicControls,initPath).subscribe(results=>{
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
     console.log('999999999');
    console.log(this.filterAttributes)
    this.loadProducts();
    //console.log(filterAttributes);

    let dynamicControls:DynamicControl[]=[];
    var path='';
    if(this.filterAttributes)
      this.filterAttributes.map(x=>x.dynamicControls).forEach(x=>dynamicControls= [...dynamicControls, ...x]);
    if(dynamicControls){
      dynamicControls.forEach(x=>{
        //if(x.value!=null )
        path+='&'+x.name+'='+x.value
      })
      if(path.length>0){
        path = '?' + path.substring(1);
      }
    }

    this.route.navigateByUrl('/products'+path);
}

pageChanged(event:any){
  // this.userParams.pageNumber=event.page;
  // this.memberService.setUserParams(this.userParams);
  // this.loadMembers();
}


}


