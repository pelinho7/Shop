import { ActualPrice } from "./actualPrice";

export class CartLine {
    id:number=0
    productId:number=0
    cartId:string='';
    quantity:number=0;
    photoUrl:string='';
    name:string='';
    actualPrice:ActualPrice;
    price:number;
   
    constructor(){}
}