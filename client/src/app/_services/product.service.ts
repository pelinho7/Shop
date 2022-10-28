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
import { Discount } from '../_models/discount';
import { ProductUpsert } from '../_models/productUpsert';
import { ProductsManagmentFiltration } from '../_models/productsManagmentFiltration';
import { ProductListItem } from '../_models/productListItem';
import { getUsersLocale } from '../_helpers/historyHelpers';
import { ProductTextAttribute } from '../_models/productTextAttribute';
import { of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl=environment.apiUrl;
  dynamicControls:DynamicControl[]=[];
  products:ProductListItem[]=[];
  productManagmentPhotos:Photo[]=[];
  productManagmentRequestParameters:string='';
  productsManagmentPage:Product[];

  public itemsPerPage = new Map([
    [10, "10"],
    [20, "20"],
    [50, "50"],
    [100, "100"],
  ]);

  constructor(private http:HttpClient) { }

  getDynamicControls(){
    return this.dynamicControls;
  }

  
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

  createProductsUrlParams(dynamicControls:DynamicControl[],pagination:Pagination){
    let path:string='';
    let params=new HttpParams();
    if(dynamicControls){
      dynamicControls.forEach(x=>{
        if(x.value == null || x.value === true) return;
        path+='&'+x.name+'='+x.value
        params=params.append(x.name,x.value);
      })
      if(path.length>0){
        path = '?' + path.substring(1);
      }
      if(pagination && pagination.page>1){
        let page='page='+pagination.page;
        if(path.length==0){
          path += '?';
        }
        else{
          path += '&';
        }
        path+=page;
      }
    }
    return [path,params]
  }

  getProducts(category:string, dynamicControls:DynamicControl[],initPath:string=''
  ,pagination:Pagination){
    let path:string='';
    let params=new HttpParams();

    var paramsResult=this.createProductsUrlParams(dynamicControls,pagination)
    path =paramsResult[0] as string;
    params =paramsResult[1] as HttpParams;

    if(initPath.length>0){
      path=initPath;
    }

    //console.log(path)
    return this.http.get<ProductListItem[]>(this.baseUrl+'products/get-products/'+category+path,{ observe: 'response'}).pipe(
      map(response=>{
        let products:ProductListItem[]=[];
        if(response.body)
          products=response.body;

        //let filterAttributes:FilterAttribute[]=[]
        //let productListData:ProductListData;
        let pagination:Pagination=new Pagination();
        if (response.headers.get('Pagination') !== null) {
          // productListData= JSON.parse(response.headers.get('ProductListData') || '{}');
          pagination= JSON.parse(response.headers.get('Pagination') || '{}');

          this.dynamicControls=[];

          //filterAttributes=productListData.filterAttributes;
          //filterAttributes.map(x=>x.dynamicControls).forEach(x=>this.dynamicControls= [...this.dynamicControls, ...x]);
          //pagination=productListData.pagination;
        }  

        this.products=products;
        let result=new GetProductsResult(this.products,pagination,path);
        return result;
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

  getProductFullData(code:string){
    var location=getUsersLocale();
    return this.http.get<ProductListItem>(this.baseUrl+'products/get-product-full-data/'+code+'?location='+location).pipe(
      map((product:ProductListItem)=>{
          return product;
        })
    )
  }

  getUpsertProduct(id:number){
    return this.http.get<ProductUpsert>(this.baseUrl+'products/get-product/'+id).pipe(
      map((product:ProductUpsert)=>{
        console.log(product)
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

  getProductAllAttributes(categoryId:number,productId:number){
    var product = this.products.find(x=>x.id == productId);
    if(product.parameters!=null){
      return of(product.parameters);
    }

    var location=getUsersLocale();

    return this.http.get<ProductTextAttribute[]>(this.baseUrl+'products/get-product-all-attributes?categoryId='+categoryId+'&productId='+productId+'&location='+location).pipe(
      map((productTextAttributes:ProductTextAttribute[])=>{
        product.parameters=productTextAttributes;
          return productTextAttributes;
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
    this.productManagmentRequestParameters='';
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
      this.productManagmentRequestParameters='?'+parametersArray.join('&');
    }

    return this.http.get<any[]>(this.baseUrl+'products/get-products-managment'+this.productManagmentRequestParameters,{ observe: 'response'}).pipe(
      map((response:any)=>{
        if(response.body)
          this.productsManagmentPage=response.body;

        let pagination:Pagination=new Pagination();
        if (response.headers.get('Pagination') !== null) {
          pagination= JSON.parse(response.headers.get('Pagination') || '{}');
        }
        return pagination;
      }));
  }
}
