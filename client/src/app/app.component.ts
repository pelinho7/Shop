import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { ResizeWindowWatcherService } from './_services/resize-window-watcher.service';
import { RouteWatcherService } from './_services/route-watcher.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css','./shared/mobile-sidenav.css']
})
export class AppComponent implements OnInit {
  title = 'Shop';
  users:any;
  // public homePage:boolean;


  constructor(private htttp:HttpClient,public resizeWindowWatcherService:ResizeWindowWatcherService
    ,private router:Router,public routeWatcherService:RouteWatcherService){

  }
  ngOnInit() {
    // //show side nav only on home page
    // this.router.events.pipe(filter(event => event instanceof NavigationEnd))
    // .subscribe((event: any) => {
    //   if(event.url==='/'|| event.url==='home'){
    //     this.homePage=true;
    //   }
    //   else{
    //     this.homePage=false;
    //   }
    // });
  }
  
  // getUsers(){
  //   this.htttp.get('https://localhost:5001/api/users').subscribe(response=>{
  //     this.users=response;
  //   },error => {console.log(error);});
  // }
}
