import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { Cart } from 'src/app/_models/cart';
import { CartService } from 'src/app/_services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  getPriceResult: boolean = false;
  constructor(public cartService: CartService
    , private router: Router) { }

  ngOnInit(): void {
    this.cartService.cart$.pipe(take(1)).subscribe(c => {
      this.cartService.prices(c.id).subscribe(x => {
        this.getPriceResult = x;
      })
    });
  }

}
