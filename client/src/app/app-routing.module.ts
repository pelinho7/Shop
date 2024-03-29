import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountDataComponent } from './account/account-data/account-data.component';
import { ChangePasswordComponent } from './account/change-password/change-password.component';
import { LogInComponent } from './account/log-in/log-in.component';
import { NewPasswordComponent } from './account/new-password/new-password.component';
import { RegisterComponent } from './account/register/register.component';
import { UserAgreementsComponent } from './account/user-agreements/user-agreements.component';
import { AttributesListComponent } from './attributes/attributes-list/attributes-list.component';
import { CartComponent } from './cart/cart/cart.component';
import { CategoriesListComponent } from './categories/categories-list/categories-list.component';
import { EmailVerificationComponent } from './email-verification/email-verification.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { HomeComponent } from './home/home.component';
import { ProductManagmentComponent } from './products-managment/product-managment/product-managment.component';
import { ProductsManagmentListComponent } from './products-managment/products-managment-list/products-managment-list.component';
import { ProductComponent } from './products/product/product.component';
import { ProductsListComponent } from './products/products-list/products-list.component';
import { ShippingAddressesComponent } from './shippingAddresses/shipping-addresses/shipping-addresses.component';
import { WarehousesListComponent } from './warehouses/warehouses-list/warehouses-list.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthenticationGuard } from './_guards/authentication.guard';

// const routes: Routes = [
//   {path:'',component:HomeComponent},
//   {path:'**',component:HomeComponent, pathMatch:'full'},
// ];

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'account',component:AccountDataComponent,canActivate:[AuthenticationGuard]},
  {path:'products/:category',component:ProductsListComponent},
  {path:'product/:code',component:ProductComponent},
  {path:'account/login',component:LogInComponent},
  {path:'account/register',component:RegisterComponent},
  {path:'account/email-confirmation',component:EmailVerificationComponent},
  {path:'account/new-password',component:NewPasswordComponent},
  {path:'cart/list',component:CartComponent},
  {
    path:'',
    runGuardsAndResolvers:'always',
    canActivate:[AuthenticationGuard],
    children:[
      {
        path:'',
        runGuardsAndResolvers:'always',
        canActivate:[AdminGuard],
        children:[
          {path:'attributes',component:AttributesListComponent},
          {path:'categories',component:CategoriesListComponent},
          {path:'products-managment',component:ProductsManagmentListComponent},
          {path:'products-managment/create',component:ProductManagmentComponent},
          {path:'products-managment/edit/:id',component:ProductManagmentComponent},
          {path:'warehouses',component:WarehousesListComponent},
        ]
      },

      {path:'account/data',component:AccountDataComponent},
      {path:'account/change-password',component:ChangePasswordComponent},
      {path:'account/user-agreements',component:UserAgreementsComponent},
      {path:'account/shipping-addresses',component:ShippingAddressesComponent},
    ]
  },
  {path:'cart',component:CartComponent},
  {path:'not-found',component:NotFoundComponent},
  {path:'server-error',component:ServerErrorComponent},
  {path:'**',component:HomeComponent, pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
