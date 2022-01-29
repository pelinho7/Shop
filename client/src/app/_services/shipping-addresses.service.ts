import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ShippingAddres } from '../_models/shippingAddres';

@Injectable({
  providedIn: 'root'
})
export class ShippingAddressesService {
  baseUrl=environment.apiUrl;
  private shippingAdressesSource=new ReplaySubject<ShippingAddres[]>(1);
  shippingAddresses$=this.shippingAdressesSource.asObservable();
  
  constructor(private http:HttpClient, private toastr:ToastrService) { }

  getShippingAddresses(){
    return this.http.get<ShippingAddres[]>(this.baseUrl+'shippingaddresses/get-shipping-addresses').pipe(
      map((shippingAdresses:ShippingAddres[])=>{
        this.shippingAdressesSource.next(shippingAdresses);
      })
    )
  }

  // upsertShippingAddres(model:any){
  //   return this.http.post<ShippingAddres>(this.baseUrl+'shippingaddresses/upsert-shipping-address',model)
  //   .toPromise().then((shippingAddres:ShippingAddres)=>{
  //           //get current list of shipping addresses base on observable
  //           var array:ShippingAddres[];
  //           this.shippingAddresses$.pipe(take(1)).subscribe(u=>array=u);
  //           var index = array.findIndex(x=>x.id==shippingAddres.id);
  //           //when addres is inserted add element to array
  //           if(index<0){
  //             array.push(shippingAddres)
  //           }
  //           //when addres is updated replace old data
  //           else{
  //             array[index]=shippingAddres;
  //           }
  //           this.shippingAdressesSource.next(array);
  //   })
  // }

  upsertShippingAddres(model:any){
    return this.http.post<ShippingAddres>(this.baseUrl+'shippingaddresses/upsert-shipping-address',model).pipe(
      map((shippingAddres:ShippingAddres)=>{
        //get current list of shipping addresses base on observable
        var array:ShippingAddres[];
        this.shippingAddresses$.pipe(take(1)).subscribe(u=>array=u);
        var index = array.findIndex(x=>x.id==shippingAddres.id);
        //when addres is inserted add element to array
        if(index<0){
          array.push(shippingAddres)
        }
        //when addres is updated replace old data
        else{
          array[index]=shippingAddres;
        }
        this.shippingAdressesSource.next(array);
      })
    )
  }
}
