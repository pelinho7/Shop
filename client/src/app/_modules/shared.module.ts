import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import {MatListModule} from '@angular/material/list';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import {DragDropModule} from '@angular/cdk/drag-drop';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { NgxDropzoneModule } from 'ngx-dropzone';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import {MatTabsModule} from '@angular/material/tabs';
import { RatingModule } from 'ngx-bootstrap/rating';
import {MatBadgeModule} from '@angular/material/badge';
import {MatStepperModule} from '@angular/material/stepper';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    TabsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    ButtonsModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot(),
    ReactiveFormsModule,
    NgxSpinnerModule,
    PopoverModule.forRoot(),
    AccordionModule.forRoot(),
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    DragDropModule,
    NgxMatSelectSearchModule,
    AngularEditorModule,
    NgxDropzoneModule,
    CarouselModule.forRoot(),
    MatTabsModule,
    RatingModule.forRoot(),
    MatBadgeModule,
    MatStepperModule,
  ],
  exports:[
    BsDropdownModule,
    BrowserAnimationsModule,
    TabsModule,
    BsDatepickerModule,
    PaginationModule,
    ButtonsModule,
    ModalModule,
    ToastrModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    PopoverModule,
    AccordionModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    DragDropModule,
    NgxMatSelectSearchModule,
    AngularEditorModule,
    NgxDropzoneModule,
    CarouselModule,
    MatTabsModule,
    RatingModule,
    MatBadgeModule,
    MatStepperModule,
  ]
})
export class SharedModule { }
