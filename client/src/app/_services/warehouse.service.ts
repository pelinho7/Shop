import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Pagination } from '../_models/pagination';
import { WarehousesFiltration } from '../_models/warehousesFiltration';
import { Warehouse } from '../_models/warehouse';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  baseUrl=environment.apiUrl;
  requestParameters:string='';
  allWarehouses:Warehouse[]=null;
  warehousesPage:Warehouse[];

  public itemsPerPage = new Map([
    [10, "10"],
    [20, "20"],
    [50, "50"],
    [100, "100"],
  ]);

    constructor(private http:HttpClient) { 
    }

  getWarehouses(attributesFiltration:WarehousesFiltration){
    this.requestParameters='';
    let parametersArray: string[] = [];
    if(attributesFiltration.code!=null && attributesFiltration.code.length>0){
      parametersArray.push('code='+attributesFiltration.code);
    }
    if(attributesFiltration.page!=null && attributesFiltration.page!=1){
      parametersArray.push('page='+attributesFiltration.page);
    }
    if(attributesFiltration.itemsPerPage!=null && attributesFiltration.itemsPerPage!=10){
      parametersArray.push('itemsPerPage='+attributesFiltration.itemsPerPage);
    }
    if(parametersArray.length>0){
      this.requestParameters='?'+parametersArray.join('&');
    }

    return this.http.get<any[]>(this.baseUrl+'warehouses'+this.requestParameters,{ observe: 'response'}).pipe(
      map((response:any)=>{
        if(response.body)
          this.warehousesPage=response.body;


        let pagination:Pagination=new Pagination();
        if (response.headers.get('Pagination') !== null) {
          pagination= JSON.parse(response.headers.get('Pagination') || '{}');
        }
        return pagination;
      }));
  }

  upsertWarehouse(model:Warehouse){
    this.allWarehouses=null;
    return this.http.post<Warehouse>(this.baseUrl+'warehouses/upsert-warehouse',model).pipe(
      map((warehouse:Warehouse)=>{
          return warehouse;
        })
    )
  }

  checkCodeNotTaken(code:string){
    return this.http.get<boolean>(this.baseUrl+'warehouses/check-code-not-taken?code='+code).pipe(
      map((result:boolean)=>{
        return result;
      })
    )
  }

  deleteWarehouse(id:number){
    this.allWarehouses=null;
    return this.http.delete(this.baseUrl+'warehouses/delete-warehouse/'+id).pipe(
      map(()=>{
       return;
      })
    )
  }
}
