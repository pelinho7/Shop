import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private accountService:AccountService,private toastr: ToastrService
    ,private router:Router){}

  canActivate(): Observable<boolean>  {
    return this.accountService.currentUser$.pipe(
      map((user:User)=>{
        if(user) {
          if(!user.roles.includes('Admin')){
            this.toastr.info('You need Admin permitions.');
            this.router.navigateByUrl('/')
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
