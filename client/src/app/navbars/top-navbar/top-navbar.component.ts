import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { LogInComponent } from 'src/app/account/log-in/log-in.component';
import { AccountService } from 'src/app/_services/account.service';
import { CartService } from 'src/app/_services/cart.service';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';
import { RouteWatcherService } from 'src/app/_services/route-watcher.service';

@Component({
  selector: 'app-top-navbar',
  templateUrl: './top-navbar.component.html',
  styleUrls: ['./top-navbar.component.css']
})
export class TopNavbarComponent implements OnInit {
  bsModalRef?: BsModalRef;
  
  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService
    ,public routeWatcherService:RouteWatcherService
    ,private modalService:BsModalService,private router:Router
    ,public accountService:AccountService
    ,public cartService:CartService) { }

  cartLinesCount:number
  ngOnInit(): void {
    this.cartService.cart$.subscribe(x=>{
      this.cartLinesCount=0;
      x?.cartLines?.forEach((element) => {
        this.cartLinesCount += element.quantity;
      });
    })
  }

  openSideNavbar(){
    var nav=(document.querySelector('#side-navbar') as HTMLElement);
    nav.style.width = '100%';
    nav.style.transition= '0.5s'

    var topNav=(document.querySelector('#top-navbar') as HTMLElement);
    topNav.style.zIndex='-1';
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  goToCart(){
    if(this.cartLinesCount>0){
      this.router.navigateByUrl('/cart');
    }
  }
}
