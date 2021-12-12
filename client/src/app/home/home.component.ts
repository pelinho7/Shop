import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Subscription } from 'rxjs/internal/Subscription';
import { distinctUntilChanged } from 'rxjs/operators';
import { ResizeWindowWatcherService } from '../_services/resize-window-watcher.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css','./../shared/mobile-sidenav.css']
})
export class HomeComponent implements OnInit {
  mobileScreen=false;
  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService) { }

  // @HostListener('window:resize', ['$event'])onResize($event:any) {
  //   if(992>$event.currentTarget.innerWidth){
  //     this.mobileScreen=true;
  //   }
  //   else{
  //     this.mobileScreen=false;
  //   }
  // }

  ngOnInit(): void {
   
  }
}
