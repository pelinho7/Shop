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
  routeSpinnerNameMap = new Map<string, string>();
  constructor(private busyService:BusyService) {
    //routeSpinnerNameMap.
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var spinnerName="main-spinner";
    var relativeUrl = request.url.replace(this.baseUrl,"")
    //get name of spinner for current request
    if(this.routeSpinnerNameMap.has(relativeUrl)){
      spinnerName=this.routeSpinnerNameMap.get(relativeUrl);
    }
    this.busyService.busy(spinnerName);
    return next.handle(request).pipe(
      //fake delay
      delay(1000),
      finalize(()=>{
        this.busyService.idle(spinnerName);
      })
    );
  }
}
