import { DynamicControl } from "./dynamicControl";
import { FilterAttribute } from "./filterAttribute";
import { Product } from "./product";

export class GetProductsResult {

    constructor(public products: Product[],public filterAttributes:FilterAttribute[]){

    }
}