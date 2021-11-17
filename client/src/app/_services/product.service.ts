import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl=environment.apiUrl;

  constructor(private http:HttpClient) { }



  getProducts(){
    // var response=this.memberCache.get(Object.values(userParams).join('-'))
    // if(response){
    //   return of(response);
    // }

    //let params=getPaginationHeaders(userParams.pageNumber,userParams.pageSize);
    let params=new HttpParams();
    params=params.append('minAge',3);
    params=params.append('maxAge',21);
    params=params.append('gender','dasdasd');
    //params=params.append('orderBy',userParams.orderBy.toString());
    
    return this.http.get<Product[]>(this.baseUrl+'products',{ observe: 'response', params });
  }
}
