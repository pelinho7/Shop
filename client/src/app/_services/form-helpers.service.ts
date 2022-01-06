import { Injectable } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FormHelpersService {

  constructor() { }

  getControlsFromArray(form:FormGroup,groupName:string){
    return (<FormArray>form.controls[groupName]).controls;
  }

  getControlFromGroup(formGroup:FormGroup,controlName:string){
    return (formGroup.controls[controlName]);
  }
}
