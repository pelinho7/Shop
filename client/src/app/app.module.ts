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
import { ShippingAddressesComponent } from './shippingAddresses/shipping-addresses/shipping-addresses.component';
import { UpsertShippingAddresComponent } from './shippingAddresses/upsert-shipping-addres/upsert-shipping-addres.component';
import { ShippingAddressCardComponent } from './shippingAddresses/shipping-address-card/shipping-address-card.component';
import { HistoryComponent } from './history/history.component';
import { AttributesListComponent } from './attributes/attributes-list/attributes-list.component';
import { SelectComponent } from './_forms/select/select.component';
import { UpsertAttributeComponent } from './attributes/upsert-attribute/upsert-attribute.component';
import { NumberInputComponent } from './_forms/number-input/number-input.component';
import { CategoriesListComponent } from './categories/categories-list/categories-list.component';
import { UpsertCategoryComponent } from './categories/upsert-category/upsert-category.component';
import { MAT_SELECTSEARCH_DEFAULT_OPTIONS, MatSelectSearchOptions } from 'ngx-mat-select-search';
import { CategoryTreeItemComponent } from './categories/category-tree-item/category-tree-item.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { ProductsManagmentListComponent } from './products-managment/products-managment-list/products-managment-list.component';
import { ProductManagmentComponent } from './products-managment/product-managment/product-managment.component';
import { ProductDescriptionParagraphComponent } from './products-managment/product-description-paragraph/product-description-paragraph.component';
import { TextOnlyParagraphTypeComponent } from './products-managment/product-description-paragraph/paragraph-types/text-only-paragraph-type/text-only-paragraph-type.component';
import { ImageOnlyParagraphTypeComponent } from './products-managment/product-description-paragraph/paragraph-types/image-only-paragraph-type/image-only-paragraph-type.component';
import { ProductImagesPickerComponent } from './products-managment/product-description-paragraph/product-images-picker/product-images-picker.component';
import { TextImageParagraphTypeComponent } from './products-managment/product-description-paragraph/paragraph-types/text-image-paragraph-type/text-image-paragraph-type.component';
import { ImageTextParagraphTypeComponent } from './products-managment/product-description-paragraph/paragraph-types/image-text-paragraph-type/image-text-paragraph-type.component';
import { ImageImageParagraphTypeComponent } from './products-managment/product-description-paragraph/paragraph-types/image-image-paragraph-type/image-image-paragraph-type.component';
import { WarehousesListComponent } from './warehouses/warehouses-list/warehouses-list.component';
import { UpsertWarehouseComponent } from './warehouses/upsert-warehouse/upsert-warehouse.component';
import { DiscountItemComponent } from './discounts/discount-item/discount-item.component';
import { SideNavbarItemComponent } from './navbars/side-navbar-item/side-navbar-item.component';
import { ProductsBreadcrumpsComponent } from './products/products-breadcrumps/products-breadcrumps.component';
import { ProductComponent } from './products/product/product.component';
import { ProductsListItemComponent } from './products/products-list-item/products-list-item.component';
import { CartComponent } from './cart/cart/cart.component';
import { UpsertProductOpinionComponent } from './products/opinions/upsert-product-opinion/upsert-product-opinion.component';
import { ProductOpinionComponent } from './products/opinions/product-opinion/product-opinion.component';
import { TextareaComponent } from './_forms/textarea/textarea.component';
import { ProductOpinionsListComponent } from './products/opinions/product-opinions-list/product-opinions-list.component';

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
    UserAgreementsComponent,
    ShippingAddressesComponent,
    UpsertShippingAddresComponent,
    ShippingAddressCardComponent,
    HistoryComponent,
    AttributesListComponent,
    SelectComponent,
    UpsertAttributeComponent,
    NumberInputComponent,
    CategoriesListComponent,
    UpsertCategoryComponent,
    CategoryTreeItemComponent,
    ConfirmDialogComponent,
    ProductsManagmentListComponent,
    ProductManagmentComponent,
    ProductDescriptionParagraphComponent,
    TextOnlyParagraphTypeComponent,
    ImageOnlyParagraphTypeComponent,
    ProductImagesPickerComponent,
    TextImageParagraphTypeComponent,
    ImageTextParagraphTypeComponent,
    ImageImageParagraphTypeComponent,
    WarehousesListComponent,
    UpsertWarehouseComponent,
    DiscountItemComponent,
    SideNavbarItemComponent,
    ProductsBreadcrumpsComponent,
    ProductComponent,
    ProductsListItemComponent,
    CartComponent,
    UpsertProductOpinionComponent,
    ProductOpinionComponent,
    TextareaComponent,
    ProductOpinionsListComponent
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
    {
      provide: MAT_SELECTSEARCH_DEFAULT_OPTIONS,
      useValue: <MatSelectSearchOptions>{
        noEntriesFoundLabel: 'No options found',
        placeholderLabel:'Search'
      }
    },
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule { }
