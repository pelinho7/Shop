import { Photo } from "./photo";

export interface Product {
    id: number;
    code:string;
    name:string;
    categoryId: number;
    photos:Photo[];
    description:string;
}