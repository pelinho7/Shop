import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product } from '../_models/Product';
import { map } from "rxjs/operators";
import { FormControl } from '@angular/forms';
import { DynamicControl } from '../_models/DynamicControl';
import { DynamicSelectOption } from '../_models/DynamicSelectOption';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl=environment.apiUrl;
  dynamicControls:DynamicControl[]=[];
  constructor(private http:HttpClient) { }

  getDynamicControls(){
    return this.dynamicControls;
  }



  getProducts(dynamicControls:DynamicControl[]){
    // var response=this.memberCache.get(Object.values(userParams).join('-'))
    // if(response){
    //   return of(response);
    // }

    //let params=getPaginationHeaders(userParams.pageNumber,userParams.pageSize);
    let params=new HttpParams();
    if(dynamicControls){
      dynamicControls.forEach(x=>{
        params=params.append(x.name,x.value);
      })
    }
    // params=params.append('minAge',3);
    // params=params.append('maxAge',21);
    // params=params.append('gender','dasdasd');
    //params=params.append('orderBy',userParams.orderBy.toString());
    
    return this.http.get<Product[]>(this.baseUrl+'products',{ observe: 'response', params }).pipe(
      map(response=>{
        let a:Product[]=[];
        if(response.body)
          a=response.body;
          var b=response.headers;
        var c1:DynamicControl=new DynamicControl();//{name='control1'}
        c1.name='control1';
        c1.value='control1';
        c1.type='text';
        var c2:DynamicControl=new DynamicControl();//{name='control1'}
        c2.name='control2';
        c2.value=12;
        c2.type='number';
        this.dynamicControls.push(c1);
        this.dynamicControls.push(c2);

        var c3:DynamicControl=new DynamicControl();//{name='control1'}
        c3.name='control3';
        c3.value=true;
        c3.type='checkbox';
        this.dynamicControls.push(c3);

        var c4:DynamicControl=new DynamicControl();//{name='control1'}
        c4.name='control4';
        c4.type='select';
        c4.value=2;
        var o1:DynamicSelectOption=new DynamicSelectOption();
        var o2:DynamicSelectOption=new DynamicSelectOption();
        o1.text='text1';o1.value=1;
        o2.text='text2';o2.value=2;
        c4.selectOptions.push(o1);
        c4.selectOptions.push(o2);
        this.dynamicControls.push(c4);
        return a;
      })
    )

    //return this.http.get<Product[]>(this.baseUrl+'products',{ params });
  }
}
