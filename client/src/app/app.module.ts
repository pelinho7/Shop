import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './_modules/shared.module';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { ProductsListComponent } from './products/products-list/products-list.component';
import { CrossNumericValidatorDirective } from './_validators/cross-numeric.validator';
import { ProductsFilterComponent } from './products/products-filter/products-filter.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { TopNavbarComponent } from './navbars/top-navbar/top-navbar.component';
import { SideNavbarComponent } from './navbars/side-navbar/side-navbar.component';
import { LogInComponent } from './account/log-in/log-in.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductsListComponent,
    CrossNumericValidatorDirective,
    ProductsFilterComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TopNavbarComponent,
    SideNavbarComponent,
    LogInComponent,
    TextInputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    //CrossNumericValidatorDirective
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:ErrorInterceptor,multi:true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
