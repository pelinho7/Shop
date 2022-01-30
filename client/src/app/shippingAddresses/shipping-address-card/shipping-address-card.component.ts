import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ShippingAddres } from 'src/app/_models/shippingAddres';
import { ShippingAddressesService } from 'src/app/_services/shipping-addresses.service';

@Component({
  selector: 'app-shipping-address-card',
  templateUrl: './shipping-address-card.component.html',
  styleUrls: ['./shipping-address-card.component.css']
})
export class ShippingAddressCardComponent implements OnInit {

  @Input() shippingAddress:ShippingAddres
  constructor(public shippingAddressesService:ShippingAddressesService
    ,private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  delete(){
    this.shippingAddressesService.deteleShippingAddress(this.shippingAddress.id).subscribe(_=>{
      this.toastr.info('Address deleted');
    })
  }
}
