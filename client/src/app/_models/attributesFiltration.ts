import { Pagination } from "./pagination";

export class AttributesFiltration extends  Pagination{
    code:string='';
    type:number=null;

    constructor(){
        super();
    }

    castJsonToClass(json:AttributesFiltration){
        if(json.code){
          this.code = json.code;
        }
        if(json.type){
          this.type = json.type;
        }
        if(json.itemsPerPage){
          this.itemsPerPage = json.itemsPerPage;
        }
        super.castJsonToClass(json);
        // if(json.page){
        //   this.page = json.page;
        // }
        // if(json.totalPages){
        //   this.totalPages = json.totalPages;
        // }
        // if(json.totalItems){
        //   this.totalItems = json.totalItems;
        // }
      }
}
