import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
    ,private agreementService:AgreementService,private accountService:AccountService
    ,private router:Router,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.agreementService.getAgreementsByType(0).subscribe((agreements:Agreement[])=>{
      this.registration=new Registration();
      this.registration.agreements=agreements;
      //console.log(this.registration.agreements)

      this.registerForm=this.fb.group({
        email:['',Validators.email],
        firstName:['',Validators.required],
        lastName:['',Validators.required],
        password:['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
        passwordRepeated:['',[Validators.required,this.formHelpersService.matchValues('password')]],
        agreements: this.fb.array([])
      })

      this.registerForm.controls['email'].setAsyncValidators(ValidateEmailNotTaken.createValidator(this.accountService));
  
      let control = <FormArray>this.registerForm.controls.agreements;
      this.registration.agreements.forEach(agreement=>{
        var group=this.fb.group(agreement);
        if(agreement.obligatory){
          group.controls['checked'].validator=Validators.requiredTrue;
        }
        //console.log('dsadsa')
        control.push(group)
    })
    //console.log('111')
    this.loadData=true;

    })
  }

  register(){
    this.accountService.register(this.registerForm.value).subscribe(user=>{
      this.toastr.info('On your email sent verification mail')
      this.router.navigateByUrl('/');
    })
  }
}
