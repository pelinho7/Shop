import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserAgreement } from '../_models/userAgreement';

@Injectable({
  providedIn: 'root'
})
export class UserAgreementsService {
  agreements:UserAgreement[]=null;
  baseUrl=environment.apiUrl;
  constructor(private http:HttpClient, private toastr:ToastrService) { }

  clear(){
    this.agreements=null;
  }

  getUserAgreements(userId: number|null){
    if(this.agreements == null){
      return this.http.get<UserAgreement[]>(this.baseUrl+'useragreements/get-user-agreements').pipe(
        map((agreements:UserAgreement[])=>{
          this.agreements=agreements;
          return agreements;
        })
      )
    }
    else{
      return of(this.agreements);
    }
  }

  updateUserAgreements(agreements: any){
    return this.http.post<UserAgreement[]>(this.baseUrl+'useragreements/update-user-agreements',agreements).pipe(
      map((updatedAgreements:UserAgreement[])=>{
        this.agreements=updatedAgreements;
      })
    );
  }
}
