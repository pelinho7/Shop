import { Component, Input, OnInit } from '@angular/core';
import { CartLine } from 'src/app/_models/cartLine';
import { CartService } from 'src/app/_services/cart.service';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {
  @Input() cartLine:CartLine;
  @Input() priceLoaded:boolean=false;
  quantity:number=0;
  constructor(private cartService:CartService) { }

  ngOnInit(): void {
    this.quantity=this.cartLine.quantity   
  }

  remove(id:number){
    this.cartService.deleteCartLine(id).subscribe(_=>{})
  }

  quantityChanged(event:any){
    var line=new CartLine();
    line.id=this.cartLine.id;
    line.quantity=this.quantity;
    this.cartService.updateCartLineQuantity(line).subscribe(result=>{
      if(!result){
        this.quantity=this.cartLine.quantity;
      }
    })
    // console.log(this.cartLine.quantity)
    // console.log(this.quantity)
  }
}
