import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';

@Component({
  selector: 'app-user-agreements',
  templateUrl: './user-agreements.component.html',
  styleUrls: ['./user-agreements.component.css','./../../shared/mobile-sidenav.css']
})
export class UserAgreementsComponent implements OnInit {

  userAgreementsForm:FormGroup;
  public loadData:boolean=false;

  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService
    ,private fb:FormBuilder
    ,private toastr:ToastrService,public mobileNavbarHelpersService:MobileNavbarHelpersService) { }

  ngOnInit(): void {
    // this.accountService.getAccountData().subscribe((data:AccountData)=>{
    //   this.accountDataForm=this.fb.group({
    //     username:[data.username],
    //     email:[data.email,Validators.email],
    //     firstName:[data.firstName,Validators.required],
    //     lastName:[data.lastName,Validators.required]
    //   })

    //   this.accountDataForm.controls['username'].setAsyncValidators(ValidateLoginNotTaken.createValidator(this.accountService));
    //   this.accountDataForm.controls['email'].setAsyncValidators(ValidateEmailNotTaken.createValidator(this.accountService));
    //   this.loadData=true;
    // })
  }

  save(){
    // this.accountService.updateAccountData(this.accountDataForm.value).subscribe((user:any)=>{
    //   this.toastr.info('Account data updated');
    // })
  }

}
