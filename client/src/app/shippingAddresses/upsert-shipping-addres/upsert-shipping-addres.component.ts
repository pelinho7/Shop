import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { ShippingAddressesService } from 'src/app/_services/shipping-addresses.service';
import { ShippingAddres } from '../../_models/shippingAddres';


@Component({
  selector: 'app-upsert-shipping-addres',
  templateUrl: './upsert-shipping-addres.component.html',
  styleUrls: ['./upsert-shipping-addres.component.css']
})
export class UpsertShippingAddresComponent implements OnInit {

  title?: string="New addres";
  shippingAddres:ShippingAddres
  shippingAddresForm:UntypedFormGroup;
 
  constructor(public bsModalRef: BsModalRef,private fb:UntypedFormBuilder
    ,private shippingAddressesService:ShippingAddressesService
    ,private toastr:ToastrService) {}

  ngOnInit(): void {
    if(this.shippingAddres.id>0){
      this.title="Edit address";
    }
    this.shippingAddresForm=this.fb.group({
      id:[this.shippingAddres.id,Validators.required],
      firstName:[this.shippingAddres.firstName,Validators.required],
      lastName:[this.shippingAddres.lastName,Validators.required],
      country:[this.shippingAddres.country,Validators.required],
      city:[this.shippingAddres.city,Validators.required],
      zipCode:[this.shippingAddres.zipCode,Validators.required],
      street:[this.shippingAddres.street],
      buildingNumber:[this.shippingAddres.buildingNumber,Validators.required],
      flatNumber:[this.shippingAddres.flatNumber],
      phone:[this.shippingAddres.phone,Validators.required],
      deleted:[this.shippingAddres.deleted],
    })

  }

  save(){
    this.shippingAddressesService.upsertShippingAddres(this.shippingAddresForm.value).subscribe(_=>{
      if(this.shippingAddres.id>0){
        this.toastr.info('Address edited')
      }
      else{
        this.toastr.info('Address added')
      }
    })
    this.bsModalRef.hide()
  }

}
