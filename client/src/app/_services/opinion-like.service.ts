import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { OpinionLike } from '../_models/opinionLike';

@Injectable({
  providedIn: 'root'
})
export class OpinionLikeService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {  }

  insertOpinionLike(model: OpinionLike) {
    return this.http.post<OpinionLike>(this.baseUrl + 'opinionlikes', model).pipe(
      map((opinion: OpinionLike) => {
        return opinion;
      })
    )
  }

  deleteOpinionLike(opinionLikeId: number) {
    return this.http.delete(this.baseUrl + 'opinionlikes/' + opinionLikeId).pipe(
      map(() => {
        return true;
      })
    )
  }
}
