import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { HistoryComponent } from 'src/app/history/history.component';
import { getUsersLocale } from 'src/app/_helpers/historyHelpers';
import { ShippingAddres } from 'src/app/_models/shippingAddres';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';
import { ShippingAddressesService } from 'src/app/_services/shipping-addresses.service';
import { UpsertShippingAddresComponent } from '../upsert-shipping-addres/upsert-shipping-addres.component';

@Component({
  selector: 'app-shipping-addresses',
  templateUrl: './shipping-addresses.component.html',
  styleUrls: ['./shipping-addresses.component.css','./../../shared/mobile-sidenav.css']
})
export class ShippingAddressesComponent implements OnInit {
  bsModalRef?: BsModalRef;
  public loadData:boolean=false;

  constructor(private modalService: BsModalService
    ,public resizeWindowWatcherService:ResizeWindowWatcherService
    ,private toastr:ToastrService
    ,public mobileNavbarHelpersService:MobileNavbarHelpersService
    ,public shippingAddressesService:ShippingAddressesService) { }

  ngOnInit(): void {
    this.shippingAddressesService.getShippingAddresses().subscribe(_=>{});
  }

  addNewShippingAddres(){
    this.upsertShippingAddresModal(new ShippingAddres());
  }

  showHistory(){

    this.shippingAddressesService.getShippingAddressesHistory().subscribe(_=>{});
    //this.upsertShippingAddresModal(new ShippingAddres());
    const initialState: ModalOptions = {
      initialState: {
        title:'Shipping Addesses History'
      },
      class:'modal-xl'
    };
    this.bsModalRef = this.modalService.show(HistoryComponent,initialState);
    this.bsModalRef.content.closeBtnName = 'Close';
  }

  upsertShippingAddresModal(shippingAddres:ShippingAddres) {
    const initialState: ModalOptions = {
      initialState: {
        shippingAddres:shippingAddres,
      },
      class:'modal-xl'
    };
    this.bsModalRef = this.modalService.show(UpsertShippingAddresComponent,initialState);
    this.bsModalRef.content.closeBtnName = 'Close';
  }

  onEdit(address:ShippingAddres){
    this.upsertShippingAddresModal(address)
  }
}
