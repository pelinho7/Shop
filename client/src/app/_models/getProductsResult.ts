import { DynamicControl } from "./dynamicControl";
import { FilterAttribute } from "./filterAttribute";
import { Pagination } from "./pagination";
import { Product } from "./product";

export class GetProductsResult {

    constructor(public products: Product[],public filterAttributes:FilterAttribute[]
        ,public pagination:Pagination){

    }
}