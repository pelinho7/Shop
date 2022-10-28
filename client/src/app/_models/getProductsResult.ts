import { DynamicControl } from "./dynamicControl";
import { FilterAttribute } from "./filterAttribute";
import { Pagination } from "./pagination";
import { Product } from "./product";
import { ProductListItem } from "./productListItem";

export class GetProductsResult {

    constructor(public products: ProductListItem[]
        ,public pagination:Pagination,public path:string){

    }
}