import { ProductTextAttribute } from "./productTextAttribute";
import { ProductNumberAttribute } from "./productNumberAttribute";
import { ProductAttributeOrder } from "./productAttributeOrder";

export class ProductAttributesWrapper {
    productAttributeOrders: ProductAttributeOrder[];
    productTextAttributes: ProductTextAttribute[];
    productNumberAttributes:ProductNumberAttribute[];

    constructor(){}
}