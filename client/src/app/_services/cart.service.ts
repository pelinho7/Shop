import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, ReplaySubject } from 'rxjs';
import { catchError, map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Cart } from '../_models/cart';
import { CartLine } from '../_models/cartLine';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  baseUrl=environment.apiUrl;
  cartId:string='';
  private cartSource=new ReplaySubject<Cart>(1);
  cart$=this.cartSource.asObservable();
  cart:Cart=null;
  constructor(private http:HttpClient) { 
  }


  setCartId(cartId:string){
    this.cartId=cartId;
    localStorage.setItem('cartId',cartId);
  }

  loadCart(){
    this.cartId = localStorage.getItem('cartId');
    
    if(this.cartId && this.cartId.length>0){
      var currentCart=null;
      this.cart$.pipe(take(1)).subscribe(c=>currentCart=c);
      //this.cartSource.next(user);
      this.http.get<Cart>(this.baseUrl+'carts/'+this.cartId).pipe(
        map((cart:Cart)=>{
          console.log(cart)
          this.cartSource.next(cart);
        })).subscribe(_=>{});
    }
  }
  
  addCartLine(cartLine:CartLine){
    cartLine.cartId=this.cartId;
    return this.http.post<CartLine>(this.baseUrl+'carts/add-to-cart',cartLine).pipe(
      map((cartLine:CartLine)=>{
        if(this.cartId == null || this.cartId=='' || this.cartId != cartLine.cartId){
          this.setCartId(cartLine.cartId);
          //create new instance of cart
          var cart=new Cart();
          cart.id=cartLine.cartId;
          cart.cartLines.push(cartLine);
          this.cartSource.next(cart);
        }
        else{
          this.cart$.pipe(take(1)).subscribe(c=>{
            var line=c.cartLines.find(x=>x.id == cartLine.id)
            if(c.cartLines.find(x=>x.id == cartLine.id)){
              line.quantity=cartLine.quantity;
            }
            else{
              c.cartLines.push(cartLine);
            }
            this.cartSource.next(c);
          })
        }

          return cartLine;
        })
    )
  }

  deleteCartLine(id:number){
    return this.http.delete(this.baseUrl + 'carts/delete-cartline/' + id).pipe(
      map(() => {
        this.cart$.pipe(take(1)).subscribe(c=>{
          var lineIndex=c.cartLines.findIndex(x=>x.id == id);
          c.cartLines.splice(lineIndex, 1);
          this.cartSource.next(c);
        })

        return true;
      })
    )
  }

  updateCartLineQuantity(cartLine:CartLine){
    cartLine.cartId=this.cartId;
    return this.http.patch<CartLine>(this.baseUrl+'carts/update-line-quantity',cartLine).pipe(
      map((cartLine:CartLine)=>{
        this.cart$.pipe(take(1)).subscribe(c=>{
          var line=c.cartLines.find(x=>x.id == cartLine.id)
          if(c.cartLines.find(x=>x.id == cartLine.id)){
            line.quantity=cartLine.quantity;
          }
          this.cartSource.next(c);
        })

          return true;
        }),
        catchError(err => of(false))
    )
  }

  prices(id:string){
    console.log('22222')
    return this.http.get<CartLine[]>(this.baseUrl + 'carts/prices/'+id).pipe(
      map((cartLines:CartLine[]) => {

        this.cart$.pipe(take(1)).subscribe(c=>{
          c.cartLines.forEach(line=>{
            var priceLine = cartLines.find(x=>x.id==line.id);
            if(priceLine){
              line.price=priceLine.price;
              line.actualPrice=priceLine.actualPrice;
            }
          })
          this.cartSource.next(c);
        })

        return true;
      }),
      catchError(x=> of(false))
    )
  }
}
