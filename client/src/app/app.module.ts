import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './_modules/shared.module';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { ProductsListComponent } from './products/products-list/products-list.component';
import { CrossNumericValidatorDirective } from './_validators/cross-numeric.validator';
import { ProductsFilterComponent } from './products/products-filter/products-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductsListComponent,
    CrossNumericValidatorDirective,
    ProductsFilterComponent
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
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
