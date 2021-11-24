import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductsListComponent } from './products/products-list/products-list.component';

// const routes: Routes = [
//   {path:'',component:HomeComponent},
//   {path:'**',component:HomeComponent, pathMatch:'full'},
// ];

const routes: Routes = [
  {path:'',component:ProductsListComponent},
  {path:'**',component:ProductsListComponent, pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
