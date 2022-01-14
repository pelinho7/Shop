import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ValidateEmailNotTaken } from 'src/app/validators/email-not-taken.validator';
import { ValidateLoginNotTaken } from 'src/app/validators/login-not-taken.validator';
import { AccountData } from 'src/app/_models/accountData';
import { AccountService } from 'src/app/_services/account.service';
import { FormHelpersService } from 'src/app/_services/form-helpers.service';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';

@Component({
  selector: 'app-account-data',
  templateUrl: './account-data.component.html',
  styleUrls: ['./account-data.component.css','./../../shared/mobile-sidenav.css']
})
export class AccountDataComponent implements OnInit {
  //public registration:Registration;
  accountDataForm:FormGroup;
  public loadData:boolean=false;

  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService
    ,private fb:FormBuilder,public formHelpersService:FormHelpersService
    ,private accountService:AccountService
    ,private toastr:ToastrService,public mobileNavbarHelpersService:MobileNavbarHelpersService) { }

  ngOnInit(): void {
    this.accountService.getAccountData().subscribe((data:AccountData)=>{
      this.accountDataForm=this.fb.group({
        username:[data.username],
        email:[data.email,Validators.email],
        firstName:[data.firstName,Validators.required],
        lastName:[data.lastName,Validators.required]
      })

      this.accountDataForm.controls['username'].setAsyncValidators(ValidateLoginNotTaken.createValidator(this.accountService));
      this.accountDataForm.controls['email'].setAsyncValidators(ValidateEmailNotTaken.createValidator(this.accountService));
      this.loadData=true;
    })
  }

  save(){
    this.accountService.updateAccountData(this.accountDataForm.value).subscribe((user:any)=>{
      this.toastr.info('Account data updated');
    })
  }

}
