import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogInComponent } from './account/log-in/log-in.component';
import { RegisterComponent } from './account/register/register.component';
import { EmailVerificationComponent } from './email-verification/email-verification.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { HomeComponent } from './home/home.component';
import { ProductsListComponent } from './products/products-list/products-list.component';

// const routes: Routes = [
//   {path:'',component:HomeComponent},
//   {path:'**',component:HomeComponent, pathMatch:'full'},
// ];

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'products',component:ProductsListComponent},
  {path:'account/login',component:LogInComponent},
  {path:'account/register',component:RegisterComponent},
  {path:'account/email-confirmation',component:EmailVerificationComponent},
  {path:'not-found',component:NotFoundComponent},
  {path:'server-error',component:ServerErrorComponent},
  {path:'**',component:HomeComponent, pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
