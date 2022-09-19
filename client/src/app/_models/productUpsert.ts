import { Discount } from "./discount";
import { Photo } from "./photo";
import { Product } from "./product";
import { ProductAmount } from "./productAmount";

export class ProductUpsert extends Product {
    productAmounts:ProductAmount[];
    productDiscounts:Discount[];
}