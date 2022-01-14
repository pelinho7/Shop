import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { of, pipe, ReplaySubject } from 'rxjs';
import { catchError, map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AccountData } from '../_models/accountData';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl=environment.apiUrl;
  private currentUserSource=new ReplaySubject<User>(1);
  currentUser$=this.currentUserSource.asObservable();

  constructor(private http:HttpClient, private toastr:ToastrService) { }

  logIn(model:any){
    return this.http.post<User>(this.baseUrl+'account/login',model).pipe(
      map((user:User)=>{
        if(user !== null){
          this.setCurrentUser(user);
        }
      })
    )
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  setCurrentUser(user:User){
    user.roles=[];
    const roles =this.getDecodedToken(user.token).role;
    Array.isArray(roles)?user.roles=roles:user.roles.push(roles);
    localStorage.setItem('user',JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  getDecodedToken(token:string){
    //atob()decode data in Base64 
    return JSON.parse(atob(token.split('.')[1]))
  }

  register(model:any){
    return this.http.post<any>(this.baseUrl+'account/register',model).pipe(
      map((user:any)=>{
        console.log(user);
        // if(user !== null){
        //   this.setCurrentUser(user);
        // }
      })
    )
  }

  checkEmailNotTaken(email:string){
    return this.http.get<boolean>(this.baseUrl+'account/check-email-not-taken?email='+email).pipe(
      map((result:boolean)=>{
        return result;
      })
    )
  }

  checkLoginNotTaken(login:string){
    return this.http.get<boolean>(this.baseUrl+'account/check-login-not-taken?login='+login).pipe(
      map((result:boolean)=>{
        return result;
      })
    )
  }

  verifyEmail(data: string) { 
    return this.http.get<User>(this.baseUrl + data).pipe(
      map((user:User)=>{
        this.setCurrentUser(user);
        return user;
      })
    )
  }

  resendVerificationEmail(user:any) { 
    return this.http.post(this.baseUrl+'account/resend-verification-email',user);
  }

  resetPassword(login:string) { 
    return this.http.get(this.baseUrl+'account/reset-password?login='+login).pipe(
      map(_ => {
        return true;
      }),
      catchError(err => {
        this.toastr.error(err);
        return of(false);
      })
    )
  }

  newPassword(model:any){
    return this.http.post(this.baseUrl+'account/new-password',model);
  }

  getAccountData(){
    return this.http.get<AccountData>(this.baseUrl+'account/data').pipe(
      map((data:AccountData)=>{
        return data;
      })
    )
  }

  updateAccountData(model:any){
    return this.http.post<User>(this.baseUrl+'account/data',model).pipe(
      map((user:User)=>{
        //reload username after update
          this.currentUser$.pipe(take(1)).subscribe(currentU=>{
            currentU.username=user.username;
            this.setCurrentUser(currentU);
          })
          return user;
        })
    )
  }

  changePassword(model:any){
    return this.http.post(this.baseUrl+'account/change-password',model);
  }
}
