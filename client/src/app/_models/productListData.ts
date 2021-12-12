import { FilterAttribute } from "./filterAttribute";
import { Pagination } from "./pagination";

export interface ProductListData{
    pagination:Pagination;
    filterAttributes:FilterAttribute[];
}