import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  logInForm:FormGroup;

  constructor(
    private fb:FormBuilder
    ,private accountService:AccountService
    ,private router:Router
    ,private toastr:ToastrService ) { }

  ngOnInit(): void {
    this.logInForm=this.fb.group({
      login:['',Validators.required],
      password:['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
    })
  }

  logIn(){
    this.accountService.logIn(this.logInForm.value).subscribe(user=>{
      this.router.navigateByUrl('/');
    })
  }

  resendVerificationEmail(){
    this.accountService.resendVerificationEmail(this.logInForm.value).subscribe(_=>{
      this.toastr.info('Verification mail was sent on your email');
      this.router.navigateByUrl('/');
    })
  }
}
