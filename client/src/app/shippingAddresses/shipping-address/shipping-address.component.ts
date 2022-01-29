import { Component, Input, OnInit } from '@angular/core';
import { ShippingAddres } from 'src/app/_models/shippingAddres';

@Component({
  selector: 'app-shipping-address',
  templateUrl: './shipping-address.component.html',
  styleUrls: ['./shipping-address.component.css']
})
export class ShippingAddressComponent implements OnInit {
  @Input() shippingAddress:ShippingAddres
  constructor() { }

  ngOnInit(): void {
  }

}
