import { Component, HostListener, OnInit } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Subscription } from 'rxjs/internal/Subscription';
import { distinctUntilChanged } from 'rxjs/operators';
import { ProductService } from 'src/app/_services/product.service';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';
import { RouteWatcherService } from 'src/app/_services/route-watcher.service';

@Component({
  selector: 'app-side-navbar',
  templateUrl: './side-navbar.component.html',
  styleUrls: ['./side-navbar.component.css','./../../shared/mobile-sidenav.css']
})
export class SideNavbarComponent implements OnInit {

  @HostListener('window:resize', ['$event'])onResize($event:any) {
    this.closeNav();
  }

  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService
    ,public routeWatcherService:RouteWatcherService) { }

  ngOnInit(): void {
  }



  closeNav(){
    (document.querySelector('#side-navbar') as HTMLElement).style.width = '0%';
    var topNav=(document.querySelector('#top-navbar') as HTMLElement);
    topNav.style.zIndex='';
  }

}
