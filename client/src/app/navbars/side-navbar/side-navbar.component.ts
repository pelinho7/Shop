import { Component, HostListener, OnInit } from '@angular/core';
import { MediaChange, MediaObserver } from '@angular/flex-layout';
import { Subscription } from 'rxjs/internal/Subscription';
import { distinctUntilChanged } from 'rxjs/operators';
import { BusyService } from 'src/app/_services/busy.service';
import { CategoryService } from 'src/app/_services/category.service';
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

  public loaded:boolean=false;
  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService
    ,public routeWatcherService:RouteWatcherService
    ,public categoryService:CategoryService
    ,private busyService:BusyService) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(){
    this.busyService.busy('side-navbar-spinner');
    this.categoryService.getCategories().subscribe((category:any)=>{
      this.busyService.idle('side-navbar-spinner');
      this.loaded=true;
    })
  }

  expandReduce(id:number){
    this.categoryService.expandControl(id);
  }

  closeNav(){
    (document.querySelector('#side-navbar') as HTMLElement).style.width = '0%';
    var topNav=(document.querySelector('#top-navbar') as HTMLElement);
    topNav.style.zIndex='';
  }

}
