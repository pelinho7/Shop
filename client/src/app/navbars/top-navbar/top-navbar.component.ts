import { Component, OnInit } from '@angular/core';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';
import { RouteWatcherService } from 'src/app/_services/route-watcher.service';

@Component({
  selector: 'app-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.css']
})
export class TopNavbarComponent implements OnInit {

  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService
    ,public routeWatcherService:RouteWatcherService) { }

  ngOnInit(): void {
  }

  openSideNavbar(){
    var nav=(document.querySelector('#side-navbar') as HTMLElement);
    nav.style.width = '100%';
    nav.style.transition= '0.5s'

    var topNav=(document.querySelector('#top-navbar') as HTMLElement);
    topNav.style.zIndex='-1';
  }

}
