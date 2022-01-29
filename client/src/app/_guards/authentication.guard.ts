import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {

  constructor(private accountService:AccountService,private toastr: ToastrService
    ,private router:Router){}

  canActivate(): Observable<boolean>  {
    return this.accountService.currentUser$.pipe(
      map((user:User)=>{
        if(user) {
          if(this.accountService.isTokenExpired(user.token)){
            this.toastr.info('Token expired.');
            this.accountService.logout();
            this.router.navigateByUrl('account/login')
            return false;
          }
          return true;
        }
        this.toastr.error('You shall not pass!');
        return false;
      })
      )
  }
  
}
