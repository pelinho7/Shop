import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from "rxjs/operators";
import { FormControl } from '@angular/forms';
import { DynamicControl } from '../_models/dynamicControl';
import { Product } from '../_models/product';
import { GetProductsResult } from '../_models/getProductsResult';
import { FilterAttribute } from '../_models/filterAttribute';
import { ProductListData } from '../_models/productListData';
import { Pagination } from '../_models/pagination';
import { Photo } from '../_models/photo';
import { ProductAttributesWrapper } from '../_models/productAttributesWrapper';
import { ProductAmount } from '../_models/productAmount';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl=environment.apiUrl;
  dynamicControls:DynamicControl[]=[];
  products:Product[]=[];
  productManagmentPhotos:Photo[]=[];

  constructor(private http:HttpClient) { }

  getDynamicControls(){
    return this.dynamicControls;
  }

  
  uploadImages(images: File[]){
    const formData = new FormData();
    for  (var i =  0; i <  images.length; i++)  {  
      formData.append("files",  images[i]);
  } 
    return this.http.post<Photo[]>(this.baseUrl+'products/upload-images?productId=1',formData).pipe(
      map((photos:Photo[])=>{
          return photos;
        })
    )
  }

  getProducts(dynamicControls:DynamicControl[],initPath:string=''){
    // var response=this.memberCache.get(Object.values(userParams).join('-'))
    // if(response){
    //   return of(response);
    // }

    //let params=getPaginationHeaders(userParams.pageNumber,userParams.pageSize);

    let path:string='';
    let params=new HttpParams();
    if(dynamicControls){
      dynamicControls.forEach(x=>{
        //if(x.value!=null )
        path+='&'+x.name+'='+x.value
        params=params.append(x.name,x.value);
      })
      if(path.length>0){
        path = '?' + path.substring(1);
      }
    }

    if(initPath.length>0){
      path=initPath;
    }

    // const headers = new HttpHeaders()
    //   .append('Content-Type', 'application/json')
    //   .append('Access-Control-Allow-Headers', 'Content-Type')
    //   .append('Access-Control-Allow-Methods', 'GET')
    //   .append('Access-Control-Allow-Origin', '*');
    
    // params=params.append('minAge',3);
    // params=params.append('maxAge',21);
    // params=params.append('gender','dasdasd');
    //params=params.append('orderBy',userParams.orderBy.toString());
    return this.http.get<Product[]>(this.baseUrl+'products/get-products'+path,{ observe: 'response'}).pipe(
      map(response=>{
        let products:Product[]=[];
        if(response.body)
          products=response.body;

        let filterAttributes:FilterAttribute[]=[]
        let productListData:ProductListData;
        let pagination:Pagination=new Pagination();
        if (response.headers.get('ProductListData') !== null) {
          productListData= JSON.parse(response.headers.get('ProductListData') || '{}');
          this.dynamicControls=[];

          filterAttributes=productListData.filterAttributes;
          filterAttributes.map(x=>x.dynamicControls).forEach(x=>this.dynamicControls= [...this.dynamicControls, ...x]);
          pagination=productListData.pagination;
        }  
        
        this.products=products;
        let result=new GetProductsResult(this.products,filterAttributes,pagination);
        return result;
      })
    )

    //return this.http.get<Product[]>(this.baseUrl+'products',{ params });
  }

  createProduct(){
    return this.http.post<Product>(this.baseUrl+'products/create-product',null).pipe(
      map((product:Product)=>{
          return product;
        })
    )
  }

  getProduct(id:number){
    return this.http.get<Product>(this.baseUrl+'products/get-product/'+id).pipe(
      map((product:Product)=>{
          return product;
        })
    )
  }

  deletePhoto(id:number){
    return this.http.delete(this.baseUrl+'products/delete-image/'+id).pipe(
      map(()=>{
       return;
      })
    )
  }

  checkCodeNotTaken(code:string){
    return this.http.get<boolean>(this.baseUrl+'products/check-code-not-taken?code='+code).pipe(
      map((result:boolean)=>{
        return result;
      })
    )
  }

  getProductAttributes(categoryId:number){
    return this.http.get<ProductAttributesWrapper>(this.baseUrl+'products/get-product-attributes/'+categoryId).pipe(
      map((productAttributesWrapper:ProductAttributesWrapper)=>{
          return productAttributesWrapper;
        })
    )
  }

  getProductAmounts(productId:number){
    return this.http.get<ProductAmount[]>(this.baseUrl+'products/get-product-amounts/'+productId).pipe(
      map((productAmounts:ProductAmount[])=>{
          return productAmounts;
        })
    )
  }
}
