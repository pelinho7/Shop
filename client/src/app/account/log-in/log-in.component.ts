import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, FormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';
import { OpinionService } from 'src/app/_services/opinion.service';
import { UrlService } from 'src/app/_services/url.service';
import { ResetPasswordComponent } from '../reset-password/reset-password.component';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  bsModalRef?: BsModalRef;
  logInForm:UntypedFormGroup;

  constructor(
    private fb:UntypedFormBuilder,private modalService: BsModalService
    ,private accountService:AccountService
    ,private router:Router
    ,private toastr:ToastrService
    ,private urlService:UrlService) { }

  ngOnInit(): void {
    this.logInForm=this.fb.group({
      login:['',Validators.required],
      password:['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
    })
  }

  logIn(){
    this.accountService.logIn(this.logInForm.value).subscribe(user=>{
      var prevUrl = this.urlService.getPreviousUrl();
      if(prevUrl.length>0){
        this.router.navigateByUrl(prevUrl);
      }
      else{
        this.router.navigateByUrl('/');
      }
    })
  }

  resendVerificationEmail(){
    this.accountService.resendVerificationEmail(this.logInForm.value).subscribe(_=>{
      this.toastr.info('Verification mail was sent on your email');
      this.router.navigateByUrl('/');
    })
  }

  openResetPasswordModal() {
    const initialState: ModalOptions = {
      initialState: {
        list: [],
        title: ''
      }
    };
    this.bsModalRef = this.modalService.show(ResetPasswordComponent, initialState);
    this.bsModalRef.content.closeBtnName = 'Close';
  }
}
