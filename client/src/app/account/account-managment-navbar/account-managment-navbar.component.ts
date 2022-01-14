import { Component, HostListener, OnInit } from '@angular/core';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';

@Component({
  selector: 'app-account-managment-navbar',
  templateUrl: './account-managment-navbar.component.html',
  styleUrls: ['./account-managment-navbar.component.css']
})
export class AccountManagmentNavbarComponent implements OnInit {

  @HostListener('window:resize', ['$event'])onResize($event:any) {
    this.closeNav();
  }

  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService) { }

  ngOnInit(): void {
  }



  closeNav(){
    (document.querySelector('#account-managment-navbar-panel') as HTMLElement).style.width = '0%';
    var topNav=(document.querySelector('#top-navbar') as HTMLElement);
    topNav.style.zIndex='';
  }

}
