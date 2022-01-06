import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ValidateEmailNotTaken } from 'src/app/validators/email-not-taken.validator';
import { Agreement } from 'src/app/_models/agreement';
import { Registration } from 'src/app/_models/registration';
import { AccountService } from 'src/app/_services/account.service';
import { AgreementService } from 'src/app/_services/agreement.service';
import { FormHelpersService } from 'src/app/_services/form-helpers.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public registration:Registration;
  registerForm:FormGroup;
  public loadData:boolean=false;
  constructor(private fb:FormBuilder,public formHelpersService:FormHelpersService
    ,private agreementService:AgreementService,private accountService:AccountService) { }

  ngOnInit(): void {
    this.agreementService.getAgreementsByType(0).subscribe((agreements:Agreement[])=>{
      // console.log(agreements);
      // var a=agreements[0] as Agreement;
      // console.log(a.checked);
      this.registration=new Registration();
      // this.registration.agreements=agreements;
      //this.getRegistrationAgreement();
      this.registration.agreements=agreements;
      console.log(this.registration.agreements)

      this.registerForm=this.fb.group({
        email:['',Validators.email],
        firstName:['',Validators.required],
        lastName:['',Validators.required],
        password:['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
        passwordRepeated:['',[Validators.required,this.matchValues('password')]],
        agreements: this.fb.array([])
      })

      this.registerForm.controls['email'].setAsyncValidators(ValidateEmailNotTaken.createValidator(this.accountService));
  
      let control = <FormArray>this.registerForm.controls.agreements;
      this.registration.agreements.forEach(agreement=>{
        console.log(agreement)
        var group=this.fb.group(agreement);
        if(agreement.obligatory){
          group.controls['checked'].validator=Validators.requiredTrue;
        }
        //console.log('dsadsa')
        control.push(group)
    })
    //console.log('111')
    this.loadData=true;


    //this.getRegistrationAgreement();
    // this.registerForm=this.fb.group({
    //   firstName:['',Validators.required],
    //   lastName:['',Validators.required],
    //   password:['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
    //   passwordRepeated:['',[Validators.required,this.matchValues('password')]],
    //   agreements: this.fb.array([])
    // })

    // let control = <FormArray>this.registerForm.controls.agreements;
    // this.registration.agreements.forEach(agreement=>{
    //   var group=this.fb.group(agreement);
    //   if(agreement.obligatory){
    //     group.controls['checked'].validator=Validators.requiredTrue;
    //   }

    //   control.push(group)
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      if (control.parent && control.parent.controls) {
        return control?.value === (control?.parent?.controls as { [key: string]: AbstractControl })[matchTo].value ? null : {isMatching: true}
      }
      return null;
    }
  }

  getRegistrationAgreement(){
    var registration:Registration=new Registration();
    registration.firstName="f";
    var a1=new Agreement();
    a1.id=1;a1.contents="dfdsfds";a1.obligatory=true;a1.checked=false;
    var a2=new Agreement();
    a2.id=1;a2.contents="false";a2.obligatory=false;a2.checked=false;
    this.registration=registration;
    registration.agreements=[a1,a2];
  }

  register(){
    this.accountService.register(this.registerForm.value).subscribe(user=>{
      //this.router.navigateByUrl('/');
    })
  }
}
