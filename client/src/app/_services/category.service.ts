import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseUrl=environment.apiUrl;
  constructor(private http:HttpClient) { 
  }

  checkCodeNotTaken(code:string){
    return this.http.get<boolean>(this.baseUrl+'categories/check-code-not-taken?code='+code).pipe(
      map((result:boolean)=>{
        return result;
      })
    )
  }
}
