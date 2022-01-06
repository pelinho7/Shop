import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl=environment.apiUrl;
  private currentUserSource=new ReplaySubject<User>(1);
  currentUser$=this.currentUserSource.asObservable();

  constructor(private http:HttpClient) { }

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
        console.log('111111');
        console.log(user);
        // if(user !== null){
        //   this.setCurrentUser(user);
        // }
      })
    )
  }

  checkEmailNotTaken(email:string){
    return this.http.post<boolean>(this.baseUrl+'account/check-email-not-taken',email).pipe(
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
}
