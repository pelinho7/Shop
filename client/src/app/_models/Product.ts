import { Photo } from "./photo";
import { ProductAmount } from "./productAmount";

export class Product {
    id: number;
    code:string;
    name:string;
    categoryId: number;
    photos:Photo[];
    description:string;
    price: number;
    //productAmounts:ProductAmount[];

    constructor(){}
}