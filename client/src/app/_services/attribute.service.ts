import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { getTimezone, getUsersLocale } from '../_helpers/historyHelpers';
import { Attribute } from '../_models/attribute';
import { AttributesFiltration } from '../_models/attributesFiltration';
import { Pagination } from '../_models/pagination';
import { History as DataHistory } from '../_models/history';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttributeService {

  baseUrl=environment.apiUrl;
  public attributeTypes = new Map([
    [null, "Type"],
    [0, "Text"],
    [1, "Number"],
    [2, "Select"],
]);

filtrationModes = new Map([
  [null, "Filtration type"],
  [0, "List of checkboxes"],
  [1, "Text field"],
  [2, "Two numeric fields"],
  [3, "Select field"],
]);


filtrationModesAttributeTypesMap: [number, number][] = [  
  [0, 0],
  [1, 0],
  [2, 1],
  [3, 2]
];


public itemsPerPage = new Map([
  [10, "10"],
  [20, "20"],
  [50, "50"],
  [100, "100"],
]);

requestParameters:string='';
allAttributes:Attribute[]=null;
attributesPage:Attribute[];
  constructor(private http:HttpClient) { 
  }


  getAttributes(attributesFiltration:AttributesFiltration){
    //var parameters='';
    this.requestParameters='';
    let parametersArray: string[] = [];
    if(attributesFiltration.code!=null && attributesFiltration.code.length>0){
      parametersArray.push('code='+attributesFiltration.code);
    }
    if(attributesFiltration.type!=null){
      parametersArray.push('type='+attributesFiltration.type);
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

    return this.http.get<any[]>(this.baseUrl+'attributes'+this.requestParameters,{ observe: 'response'}).pipe(
      map((response:any)=>{
        if(response.body)
          this.attributesPage=response.body;


        let pagination:Pagination=new Pagination();
        if (response.headers.get('Pagination') !== null) {
          pagination= JSON.parse(response.headers.get('Pagination') || '{}');
        }
        return pagination;
      }));
  }

  getAllAttributes(){
    if(this.allAttributes == null){
      return this.http.get<Attribute[]>(this.baseUrl+'attributes/get-all-attributes').pipe(
        map((attributes:Attribute[])=>{
          this.allAttributes = attributes;
          return attributes;
        }));
    }
    else{
      return of(this.allAttributes);
    }
  }

  checkCodeNotTaken(code:string){
    return this.http.get<boolean>(this.baseUrl+'attributes/check-code-not-taken?code='+code).pipe(
      map((result:boolean)=>{
        return result;
      })
    )
  }

  upsertAttribute(model:Attribute){
    this.allAttributes=null;
    return this.http.post<Attribute>(this.baseUrl+'attributes/upsert-attribute',model).pipe(
      map((attribute:Attribute)=>{
          return attribute;
        })
    )
  }

 
  deleteAttribute(id:number){
    this.allAttributes=null;
    return this.http.delete(this.baseUrl+'attributes/delete-attribute/'+id).pipe(
      map(()=>{
       return;
      })
    )
  }

  getAttributeHistory(id:number){
    var timezone=getTimezone();
    var location=getUsersLocale();
  
    return this.http.get<DataHistory[]>(this.baseUrl+'attributes/get-attribute-history?id='+id+'&timezone='+timezone+'&location='+location).pipe(
      map((historyList:DataHistory[])=>{
        return historyList;
      })
    )
  }
  
}
