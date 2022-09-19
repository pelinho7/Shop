import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Discount } from '../_models/discount';
import { Pagination } from '../_models/pagination';
import { Photo } from '../_models/photo';
import { Product } from '../_models/product';
import { ProductAmount } from '../_models/productAmount';
import { ProductAttributesWrapper } from '../_models/productAttributesWrapper';
import { ProductsManagmentFiltration } from '../_models/productsManagmentFiltration';
import { ProductUpsert } from '../_models/productUpsert';

@Injectable({
  providedIn: 'root'
})
export class ProductManagmentService {
  baseUrl=environment.apiUrl;
  productManagmentPhotos:Photo[]=[];
  productManagmentRequestParameters:string='';
  productsManagmentPage:Product[];
  pagination:Pagination;

  public itemsPerPage = new Map([
    [10, "10"],
    [20, "20"],
    [50, "50"],
    [100, "100"],
  ]);

  constructor(private http:HttpClient) { }

  uploadImages(images: File[],productId:number){
    const formData = new FormData();
    for  (var i =  0; i <  images.length; i++)  {  
      formData.append("files",  images[i]);
  } 
    return this.http.post<Photo[]>(this.baseUrl+'products/upload-images?productId='+productId,formData).pipe(
      map((photos:Photo[])=>{
          return photos;
        })
    )
  }

  createProduct(){
    return this.http.post<ProductUpsert>(this.baseUrl+'products/create-product',null).pipe(
      map((product:ProductUpsert)=>{
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

  getUpsertProduct(id:number){
    return this.http.get<ProductUpsert>(this.baseUrl+'products/get-product/'+id).pipe(
      map((product:ProductUpsert)=>{
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

  getProductAttributes(categoryId:number,productId:number){
    return this.http.get<ProductAttributesWrapper>(this.baseUrl+'products/get-product-attributes?categoryId='+categoryId+'&productId='+productId).pipe(
      map((productAttributesWrapper:ProductAttributesWrapper)=>{
          return productAttributesWrapper;
        })
    )
  }

  getProductDiscounts(productId:number){
    return this.http.get<Discount[]>(this.baseUrl+'products/get-product-discounts/'+productId).pipe(
      map((discounts:Discount[])=>{
          return discounts;
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

  updateProduct(model:ProductUpsert){
    return this.http.post<ProductUpsert>(this.baseUrl+'products/update-product',model).pipe(
      map((product:ProductUpsert)=>{
          return product;
        })
    )
  }

  getProductsManagment(productsFiltration:ProductsManagmentFiltration){
    //var parameters='';
    var productManagmentRequestParametersTemp='';
    //this.productManagmentRequestParameters='';
    let parametersArray: string[] = [];
    if(productsFiltration.code!=null && productsFiltration.code.length>0){
      parametersArray.push('code='+productsFiltration.code);
    }
    if(productsFiltration.categoryId!=null){
      parametersArray.push('categoryId='+productsFiltration.categoryId);
    }
    if(productsFiltration.page!=null && productsFiltration.page!=1){
      parametersArray.push('page='+productsFiltration.page);
    }
    if(productsFiltration.itemsPerPage!=null && productsFiltration.itemsPerPage!=10){
      parametersArray.push('itemsPerPage='+productsFiltration.itemsPerPage);
    }
    if(parametersArray.length>0){
      productManagmentRequestParametersTemp='?'+parametersArray.join('&');
    }

    if(this.productManagmentRequestParameters == productManagmentRequestParametersTemp && this.pagination){
      return of(this.pagination)
    }
    this.productManagmentRequestParameters=productManagmentRequestParametersTemp;
    return this.http.get<any[]>(this.baseUrl+'products/get-products-managment'+this.productManagmentRequestParameters,{ observe: 'response'}).pipe(
      map((response:any)=>{
        if(response.body)
          this.productsManagmentPage=response.body;

        //let pagination:Pagination=new Pagination();
        if (response.headers.get('Pagination') !== null) {
          this.pagination= JSON.parse(response.headers.get('Pagination') || '{}');
        }
        return this.pagination;
      }));
  }

  deleteProduct(id:number){
    //force reload list
    this.pagination=null;
    return this.http.delete(this.baseUrl+'products/delete-product/'+id).pipe(
      map(()=>{
       return;
      })
    )
  }

  resetCashedData(){
    this.pagination=null;
  }
}
