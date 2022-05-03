import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { HistoryComponent } from 'src/app/history/history.component';
import { Attribute } from 'src/app/_models/attribute';
import { AttributesFiltration } from 'src/app/_models/attributesFiltration';
import { Pagination } from 'src/app/_models/pagination';
import { AttributeService } from 'src/app/_services/attribute.service';
import { MobileNavbarHelpersService } from 'src/app/_services/mobile-navbar-helpers.service';
import { UpsertAttributeComponent } from '../upsert-attribute/upsert-attribute.component';
import { History as DataHistory} from '../../_models/history';

@Component({
  selector: 'app-attributes-list',
  templateUrl: './attributes-list.component.html',
  styleUrls: ['./attributes-list.component.css']
})
export class AttributesListComponent implements OnInit {

  loaded=false;
  bsModalRef?: BsModalRef;
  attributesFiltrationForm:FormGroup;
  pagination:Pagination;
  attributesFiltrationParams: AttributesFiltration;

  constructor(public attributeService:AttributeService,private fb:FormBuilder
    ,private activatedRoute: ActivatedRoute
    ,private modalService: BsModalService
    ,private toastr:ToastrService,private router:Router
    ,public mobileNavbarHelpersService:MobileNavbarHelpersService) { }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.attributesFiltrationParams=new AttributesFiltration();
    this.activatedRoute.queryParams.subscribe(params => {
      this.attributesFiltrationParams=new AttributesFiltration();
      this.attributesFiltrationParams.castJsonToClass((params as AttributesFiltration));

      this.attributesFiltrationForm=this.fb.group({
        code:[this.attributesFiltrationParams.code,Validators.maxLength],
        type:[this.attributesFiltrationParams.type],
        itemsPerPage:[this.attributesFiltrationParams.itemsPerPage],
      })
  });

    this.getAttributes();
  }


  getAttributes(){
    this.attributeService.getAttributes(this.attributesFiltrationParams).subscribe((pagination:Pagination)=>{
      this.pagination=pagination;
      this.router.navigateByUrl('/attributes'+this.attributeService.requestParameters);
      this.loaded=true;
    })
  }

  pageChanged(event:any){
    if(!this.loaded)return;
    this.attributesFiltrationParams.page=event.page;
    console.log(event)
    this.getAttributes();
  }

  filter(){
    this.attributesFiltrationParams=this.attributesFiltrationForm.value;
    this.attributesFiltrationParams.page=1;
    this.getAttributes();
  }

  edit(id:number){
    var attribute = this.attributeService.attributesPage.find(x=>x.id==id);
    this.upsertShippingAddresModal(attribute);
  }

  onDelete(id:number){
    var attribute = this.attributeService.attributesPage.find(x=>x.id==id);
    this.attributeService.deleteAttribute(id).subscribe(_=>{
      this.getAttributes();
    })
  }

  upsertShippingAddresModal(attribute:Attribute) {
    const initialState: ModalOptions = {
      initialState: {
        attribute:attribute,
      },
      class:'modal-lg'
    };
    this.bsModalRef = this.modalService.show(UpsertAttributeComponent,initialState);
    this.bsModalRef.content.closeBtnName = 'Close';
    console.log(this.bsModalRef.content)
    this.bsModalRef.onHidden.subscribe((reason: string | any) => {

      if(this.bsModalRef.content.saved){
        this.getAttributes();
      }
    })
  }

  addNewAttribute(){
    this.upsertShippingAddresModal(new Attribute())
  }

  onEdit(attribute:Attribute){
    this.upsertShippingAddresModal(attribute)
  }

  showHistory(id:number){
    this.attributeService.getAttributeHistory(id).subscribe((history:DataHistory[])=>{
      const initialState: ModalOptions = {
        initialState: {
          title:'Attribute History',
          historyList:history
        },
        class:'modal-xl'
      };
      this.bsModalRef = this.modalService.show(HistoryComponent,initialState);
      this.bsModalRef.content.closeBtnName = 'Close';
    });

  }

}
