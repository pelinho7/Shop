import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { of, ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { FilterAttribute } from '../_models/filterAttribute';
import { BusyService } from './busy.service';

@Injectable({
  providedIn: 'root'
})
export class ProductsFilterService {
  baseUrl=environment.apiUrl;
  private filtersSource=new ReplaySubject<FilterAttribute[]>(1);
  filters$=this.filtersSource.asObservable();
  private url:string='';
  constructor(private http:HttpClient
    ,private busyService:BusyService
    ,private activatedRoute:ActivatedRoute) { }

  getFilterControls(category:string,currentUrl:string){
    if(this.url.toLowerCase() == currentUrl.toLocaleLowerCase()){
      // var filters:FilterAttribute[];
      // this.filters$.pipe(take(1)).subscribe(f=>filters=f);
      // this.activatedRoute.queryParams.subscribe(a=>console.log(a))
      //console.log(filters)
      return of(true)
    }
    else{
      return this.http.get<FilterAttribute[]>(this.baseUrl+'products/get-filters/'+category).pipe(
        map((filters:FilterAttribute[])=>{
          
          this.filtersSource.next(filters);
          this.url=currentUrl;
          this.loadValuesFromUrlParams(filters)
            return  true;
          })
      )
    }
  }

  loadValuesFromUrlParams(filters:FilterAttribute[]){
    this.activatedRoute.queryParamMap.subscribe(params=>{
      filters.forEach(filter => {
        filter.dynamicControls.forEach(control=>{
          if(params.get(control.name)){
            var value=params.get(control.name);
            if(filter.type=='checkbox'){
              control.value=value=='true';//Boolean(value);
            }
            else{
              control.value=params.get(control.name);
            }
          }
        })
      });
  })
  }
}
