import { Pagination } from "./pagination";

export class WarehousesFiltration extends  Pagination{
    code:string='';
    type:number=null;

    constructor(){
        super();
    }

    castJsonToClass(json:WarehousesFiltration){
        if(json.code){
          this.code = json.code;
        }

        if(json.itemsPerPage){
          this.itemsPerPage = json.itemsPerPage;
        }
        super.castJsonToClass(json);
      }
}
