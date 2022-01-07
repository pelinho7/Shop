import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  resetPasswordForm:FormGroup;

  constructor(
    private fb:FormBuilder,public bsModalRef: BsModalRef
    ,private accountService:AccountService
    ,private router:Router,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.resetPasswordForm=this.fb.group({
      login:['',Validators.required],
    })
  }

  resetPassword(){
    var login:string = this.resetPasswordForm.controls['login'].value;
    this.accountService.resetPassword(login).subscribe((result:boolean)=>{
      if(result){
        this.toastr.info('On your email was sent mail');
        this.bsModalRef.hide();
        this.bsModalRef=null;
        this.router.navigateByUrl('/');
      }
    })
  }
}
