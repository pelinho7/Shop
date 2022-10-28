import { ActualPrice } from "./actualPrice";
import { Product } from "./product";
import { ProductTextAttribute } from "./productTextAttribute";

export class ProductListItem extends Product {
    mainPhotoUrl:string;
    actualPrice:ActualPrice;
    parameters:ProductTextAttribute[]=null;

    constructor(){
        super();
    }
}