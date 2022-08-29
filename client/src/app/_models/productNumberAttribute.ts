import { ProductAttribute } from "./productAttribute";

export class ProductNumberAttribute extends ProductAttribute {
    value: number;
    decimalPlaces:number;

    constructor(){
        super();
    }
}