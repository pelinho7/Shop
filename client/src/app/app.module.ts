import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
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
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { RegisterComponent } from './account/register/register.component';
import { CheckboxInputComponent } from './_forms/checkbox-input/checkbox-input.component';
import { EmailVerificationComponent } from './email-verification/email-verification.component';
import { ResetPasswordComponent } from './account/reset-password/reset-password.component';
import { NewPasswordComponent } from './account/new-password/new-password.component';
import { AccountManagmentNavbarComponent } from './account/account-managment-navbar/account-managment-navbar.component';
import { AccountDataComponent } from './account/account-data/account-data.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { ChangePasswordComponent } from './account/change-password/change-password.component';
import { UserAgreementsComponent } from './account/user-agreements/user-agreements.component';

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
    TextInputComponent,
    RegisterComponent,
    CheckboxInputComponent,
    EmailVerificationComponent,
    ResetPasswordComponent,
    NewPasswordComponent,
    AccountManagmentNavbarComponent,
    AccountDataComponent,
    ChangePasswordComponent,
    UserAgreementsComponent
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
    {provide:HTTP_INTERCEPTORS,useClass:LoadingInterceptor,multi:true},
    {provide:HTTP_INTERCEPTORS,useClass:JwtInterceptor,multi:true},
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
