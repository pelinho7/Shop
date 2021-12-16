import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(private htttp:HttpClient,public resizeWindowWatcherService:ResizeWindowWatcherService
    ,private router:Router,public routeWatcherService:RouteWatcherService){

  }
  ngOnInit() {
  }
}
