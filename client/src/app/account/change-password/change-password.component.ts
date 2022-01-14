import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';
import { FormHelpersService } from 'src/app/_services/form-helpers.service';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  changePasswordForm:FormGroup;
  public loadData:boolean=false;
  
  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService
    ,private fb:FormBuilder,public formHelpersService:FormHelpersService
    ,private accountService:AccountService,private router:Router
    ,private toastr:ToastrService,public mobileNavbarHelpersService:MobileNavbarHelpersService) { }

  ngOnInit(): void {
    this.changePasswordForm=this.fb.group({
      actualPassword:['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
      newPassword:['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
      newPasswordRepeated:['',[Validators.required,this.formHelpersService.matchValues('newPassword')]],
    });

    this.loadData=true;
  }

  changePassword(){
    this.accountService.changePassword(this.changePasswordForm.value).subscribe(_=>{
      this.toastr.info('Password changed');
      this.accountService.logout();
      this.router.navigateByUrl('/');
    })
  }
}
