import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { delay, finalize } from 'rxjs/operators';
import { BusyService } from '../_services/busy.service';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  baseUrl=environment.apiUrl;
  routeSpinnerNameMap = new Map<string, string>()
  constructor(private busyService:BusyService) {
    this.routeSpinnerNameMap.set("account/check-email-not-taken","");
    this.routeSpinnerNameMap.set("account/check-login-not-taken","");
    this.routeSpinnerNameMap.set("shippingaddresses/get-shipping-addresses-history","history-spinner");
    this.routeSpinnerNameMap.set("attributes/check-code-not-taken","");
    this.routeSpinnerNameMap.set("attributes/upsert-attribute","attribute-spinner");
    this.routeSpinnerNameMap.set("categories/check-code-not-taken","");
    this.routeSpinnerNameMap.set("products/upload-images","product-managment-images-spinner");
    this.routeSpinnerNameMap.set("products/check-code-not-taken","");
    this.routeSpinnerNameMap.set("categories","");
    this.routeSpinnerNameMap.set("warehouses/check-code-not-taken","");
    this.routeSpinnerNameMap.set("warehouses/upsert-warehouse","warehouse-spinner");

    //this.routeSpinnerNameMap.set("attributes/get-all-attributes","category-spinner");
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var spinnerName="main-spinner";
    var relativeUrl = request.url.replace(this.baseUrl,"")
    //remove data from url
    if(relativeUrl.indexOf('?')>=0){
      relativeUrl=relativeUrl.substring(0,relativeUrl.indexOf('?'));
    }
    //get name of spinner for current request
    if(this.routeSpinnerNameMap.has(relativeUrl)){
      spinnerName=this.routeSpinnerNameMap.get(relativeUrl);
    }
    //run spinner only when spinnerName.length>0 (when == 0 thet means thet for current request not run spinner)
    if(spinnerName.length>0){
      this.busyService.busy(spinnerName);
    }

    return next.handle(request).pipe(
      //fake delay
      delay(1000),
      finalize(()=>{
        if(spinnerName.length>0){
          this.busyService.idle(spinnerName);
        }
      })
    );
  }
}
