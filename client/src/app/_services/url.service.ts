import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  prevoiusUrl:string='';
  constructor() { }

  setPreviousUrl(url:string){
    this.prevoiusUrl=url;
  }

  getPreviousUrl(){
    return this.prevoiusUrl;
  }
}
