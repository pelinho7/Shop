import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Pagination } from 'src/app/_models/pagination';
import { ProductsManagmentFiltration } from 'src/app/_models/productsManagmentFiltration';
import { BusyService } from 'src/app/_services/busy.service';
import { CategoryService } from 'src/app/_services/category.service';
import { ConfirmService } from 'src/app/_services/confirm.service';
import { ProductManagmentService } from 'src/app/_services/product-managment.service';
import { ProductService } from 'src/app/_services/product.service';
import { UrlService } from 'src/app/_services/url.service';

@Component({
  selector: 'app-products-managment-list',
  templateUrl: './products-managment-list.component.html',
  styleUrls: ['./products-managment-list.component.css']
})
export class ProductsManagmentListComponent implements OnInit {
  
  productsManagmentFiltrationForm:UntypedFormGroup;
  pagination:Pagination;
  productsManagmentFiltrationParams: ProductsManagmentFiltration;
  categoryMap:Map<number, string>;
  loaded:boolean=false;
  constructor(private fb:UntypedFormBuilder
    ,private activatedRoute: ActivatedRoute
    ,private router:Router
    ,public productService:ProductManagmentService
    ,private categoryService:CategoryService
    ,private urlService:UrlService
    ,private confirmService:ConfirmService
    ,private busyService:BusyService) { }

  ngOnInit(): void {
    this.busyService.busy('main-spinner');
    this.categoryService.getCategories().subscribe(categories=>{
      this.categoryMap=new Map<number, string>();
      var categoryMapTemp=this.categoryService.categoryTree2Map(categories,new Map<number, string>());
      this.categoryMap.set(null,'');
      for (let [key, value] of categoryMapTemp) {
        this.categoryMap.set(key,value);
      }
  
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.productsManagmentFiltrationParams=new ProductsManagmentFiltration();

      this.activatedRoute.queryParams.subscribe(params => {
        this.productsManagmentFiltrationParams=new ProductsManagmentFiltration();
        this.productsManagmentFiltrationParams.castJsonToClass((params as ProductsManagmentFiltration));

        this.productsManagmentFiltrationForm=this.fb.group({
          code:[this.productsManagmentFiltrationParams.code],
          categoryId:[this.productsManagmentFiltrationParams.categoryId],
          itemsPerPage:[this.productsManagmentFiltrationParams.itemsPerPage],
        })
    });
    this.busyService.idle('main-spinner');
    this.getProducts();
    })
  }

  filter(){
    this.productsManagmentFiltrationParams=this.productsManagmentFiltrationForm.value;
    this.productsManagmentFiltrationParams.page=1;
    this.getProducts();
  }

  getProducts(){
    this.productService.getProductsManagment(this.productsManagmentFiltrationParams).subscribe((pagination:Pagination)=>{
      this.pagination=pagination;
      this.router.navigateByUrl('/products-managment'+this.productService.productManagmentRequestParameters);
      this.loaded=true;
    })
  }

  pageChanged(event:any){
    if(!this.loaded)return;
    this.productsManagmentFiltrationParams.page=event.page;
    this.getProducts();
  }

  upsertProduct(id:number){
    this.urlService.setPreviousUrl(this.router.url);
    if(id){
      this.router.navigateByUrl('/products-managment/edit/'+id);
    }
    else{
      this.router.navigateByUrl('/products-managment/create');
    }
  }

  deleteProduct(id:number){
    this.confirmService.confirm('Confirm delete message', 'This cannot be undone. Selected product will be deleted').subscribe(result=>{

      if(result){
        this.productService.deleteProduct(id).subscribe(_=>{
          this.getProducts();
        })
      }
    })
  }
}
