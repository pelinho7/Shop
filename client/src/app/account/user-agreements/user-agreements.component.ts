import { Component, OnInit } from '@angular/core';
import { UntypedFormArray, UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserAgreement } from 'src/app/_models/userAgreement';
import { FormHelpersService } from 'src/app/_services/form-helpers.service';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';
import { UserAgreementsService } from 'src/app/_services/user-agreements.service';

@Component({
  selector: 'app-user-agreements',
  templateUrl: './user-agreements.component.html',
  styleUrls: ['./user-agreements.component.css','./../../shared/mobile-sidenav.css']
})
export class UserAgreementsComponent implements OnInit {

  userAgreementsForm:UntypedFormGroup;
  public loadData:boolean=false;

  constructor(public resizeWindowWatcherService:ResizeWindowWatcherService
    ,private fb:UntypedFormBuilder,private userAgreementsService:UserAgreementsService
    ,public formHelpersService:FormHelpersService
    ,private toastr:ToastrService,public mobileNavbarHelpersService:MobileNavbarHelpersService) { }

  ngOnInit(): void {
    this.userAgreementsService.getUserAgreements(null).subscribe((agreements:UserAgreement[])=>{
      this.userAgreementsForm=this.fb.group({
          agreements: this.fb.array([])
      })

      let control = <UntypedFormArray>this.userAgreementsForm.controls.agreements;
      agreements.forEach(agreement=>{
        var group=this.fb.group(agreement);
        control.push(group)
    })

    this.loadData=true;
    })
  }

  save(){
    this.userAgreementsService.updateUserAgreements(this.userAgreementsForm.value.agreements).subscribe(_=>{
      this.toastr.info('Agreements updated');
    })
  }

}
