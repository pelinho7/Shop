import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ShippingAddressesService } from '../_services/shipping-addresses.service';
import { History } from '../_models/history';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  title?: string="New addres";
  public historyList:History[];
 
  constructor(public bsModalRef: BsModalRef, private shippingAddressesService:ShippingAddressesService) {}

  ngOnInit(): void {
    // this.shippingAddressesService.getShippingAddressesHistory().subscribe(historyList=>{
    //   this.historyList=historyList;
    // });

  }


}
