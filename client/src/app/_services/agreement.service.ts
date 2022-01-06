import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Agreement } from '../_models/agreement';

@Injectable({
  providedIn: 'root'
})
export class AgreementService {
  baseUrl=environment.apiUrl;
  constructor(private http:HttpClient) { }

  getAgreementsByType(type:number){
    return this.http.get<Agreement[]>(this.baseUrl+'agreements/agreements-by-type?type='+type).pipe(
      map((agreements:Agreement[])=>{
        return agreements;
      })
    )
  }
}
