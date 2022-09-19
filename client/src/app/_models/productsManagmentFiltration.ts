import { Pagination } from "./pagination";

export class ProductsManagmentFiltration extends  Pagination{
    code:string='';
    categoryId:number;

    constructor(){
        super();
    }

    castJsonToClass(json:ProductsManagmentFiltration){
        if(json.code){
          this.code = json.code;
        }
        if(json.categoryId){
          this.categoryId = json.categoryId;
        }
        if(json.itemsPerPage){
          this.itemsPerPage = json.itemsPerPage;
        }
        super.castJsonToClass(json);
      }
}