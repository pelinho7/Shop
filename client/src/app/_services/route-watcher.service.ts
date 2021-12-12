import { Injectable } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RouteWatcherService {
  private homePage=new ReplaySubject <boolean>(1);
  homePage$=this.homePage.asObservable();
  
  constructor(private router:Router) {
     //show side nav only on home page
     this.router.events.pipe(filter(event => event instanceof NavigationEnd))
     .subscribe((event: any) => {
       if(event.url==='/'|| event.url==='home'){
        this.homePage.next(true);
       }
       else{
        this.homePage.next(false);
       }
     });
   }
}
