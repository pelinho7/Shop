import { Photo } from "./photo";
import { ProductAmount } from "./productAmount";

export interface Product {
    id: number;
    code:string;
    name:string;
    categoryId: number;
    photos:Photo[];
    description:string;
    productAmounts:ProductAmount[];
}