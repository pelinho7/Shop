import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
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
    ,private accountService:AccountService) { }

  ngOnInit(): void {
    this.logInForm=this.fb.group({
      login:['',Validators.required],
      password:['',[Validators.required,Validators.minLength(4),Validators.maxLength(8)]],
    })
  }

  logIn(){
    this.accountService.logIn(this.logInForm.value).subscribe(user=>{

    })
  }
}
