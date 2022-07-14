import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products-managment-list',
  templateUrl: './products-managment-list.component.html',
  styleUrls: ['./products-managment-list.component.css']
})
export class ProductsManagmentListComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  a(){
    console.log('1111111111111')
  }

  upsertProduct(id:number){
    if(id){
      this.router.navigateByUrl('/products-management/edit/'+id);
    }
    else{
      this.router.navigateByUrl('/products-management/create');
    }
  }
}
