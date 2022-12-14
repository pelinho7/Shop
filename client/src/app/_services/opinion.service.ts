import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Opinion } from '../_models/opinion';
import { Pagination } from '../_models/pagination';

@Injectable({
  providedIn: 'root'
})
export class OpinionService {

  baseUrl = environment.apiUrl;
  public opinionSorting = new Map([
    [0, "From newest"],
    [1, "From oldest"],
    [2, "From most popular"],
  ]);
  sortingType: number = 0;
  opinions: Opinion[] = [];
  pagination: Pagination = new Pagination();
  requestParameters: string = '';
  productId: number = 0;
  constructor(private http: HttpClient) {
    this.pagination.itemsPerPage = 3;
    this.pagination.page = 0;
  }

  upsertOpinion(model: Opinion) {
    if (model.id == 0) {
      return this.http.post<any>(this.baseUrl + 'opinions', model).pipe(
        map((opinion: any) => {
          return opinion;
        })
      )
    }
    else {
      return this.http.put<any>(this.baseUrl + 'opinions', model).pipe(
        map((opinion: any) => {
          var oldOpinionIndex = this.opinions.findIndex(x => x.id == opinion.id);
          this.opinions[oldOpinionIndex] = opinion;
          return opinion;
        })
      )
    }
  }

  setSortingType(sortingType:number){
    this.sortingType=sortingType;
  }

  resetOpinionService(){
    this.productId = 0;
    this.requestParameters = '';
    this.pagination.page = 0;
    this.sortingType=0;
  }

  getLoadedOpinionById(opinionId:number){
    return this.opinions.find(x=>x.id==opinionId);
  }

  getOpinions(productId: number, reload: boolean = false) {
    if (productId != this.productId || reload) {
      this.productId = productId;
      this.requestParameters = '';
      this.pagination.page = 0;
      if(productId != this.productId){
        this.sortingType=0;
      }
    }
    this.pagination.page++;
    //var parameters='';
    this.requestParameters = '';
    let parametersArray: string[] = [];
    parametersArray.push('productId=' + productId);

    if (this.pagination.page != null && this.pagination.page != 1) {
      parametersArray.push('page=' + this.pagination.page);
    }
    if (this.pagination.itemsPerPage != null && this.pagination.itemsPerPage != 10) {
      parametersArray.push('itemsPerPage=' + this.pagination.itemsPerPage);
    }

    parametersArray.push('sortingType=' + this.sortingType);
    if (parametersArray.length > 0) {
      this.requestParameters = '?' + parametersArray.join('&');
    }

    return this.http.get<any[]>(this.baseUrl + 'opinions' + this.requestParameters, { observe: 'response' }).pipe(
      map((response: any) => {
        if (response.body)
        if(reload){
          this.opinions = [];
        }
          this.opinions.push(...response.body);
        let pagination: Pagination = new Pagination();
        if (response.headers.get('Pagination') !== null) {
          pagination = JSON.parse(response.headers.get('Pagination') || '{}');
        }
        
        this.pagination.totalPages = pagination.totalPages;
        return true;
      }));
  }

  deleteOpinion(opinionId: number) {
    return this.http.delete(this.baseUrl + 'opinions/' + opinionId).pipe(
      map(() => {
        return true;
      })
    )
  }
}
