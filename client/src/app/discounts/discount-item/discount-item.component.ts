import { formatDate } from '@angular/common';
import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ConfirmService } from 'src/app/_services/confirm.service';
import { FormHelpersService } from 'src/app/_services/form-helpers.service';

@Component({
  selector: 'app-discount-item',
  templateUrl: './discount-item.component.html',
  styleUrls: ['./discount-item.component.css']
})
export class DiscountItemComponent implements OnInit {

  datePickerConfig = {
    dateInputFormat: 'YYYY-MM-DD',
    isAnimated: true,
    adaptivePosition: true
  };

  public discountTypes = new Map([
    [0, "Percentage"],
    [1, "Quota"],
  ]);
  @Input() decimalPlaces:number = 2;
  @ViewChild('numberInput') input:ElementRef;
  @ViewChild('typeSelect') typeSelect:ElementRef;
  @Input() formGroup:FormGroup
  @Output() removeEvent: EventEmitter<number> = new EventEmitter();
  public deleted:boolean=false;
  @Input() index:number;
  constructor(public formHelpersService:FormHelpersService
    ,private toastr:ToastrService
    ,private confirmService:ConfirmService) { }

  ngOnInit(): void {
  }

  setDiscountInput(value:string){
    this.input.nativeElement.value=parseFloat(value).toFixed(this.decimalPlaces)
  }

  ngAfterViewInit(): void {
    this.setDiscountInput(this.input.nativeElement.value);
  }

  setDecimalPlaces($event:any) {
    var value:string=$event.target.value;
    if(!value || value.length == 0){
      value='0';
    }
    else if(parseFloat(value)<0){
      value='0';
    }
    else if(parseFloat(value)>=100 && this.typeSelect.nativeElement.value){
      this.toastr.info("You can't set greater discount than 99.99%")
      value='0';
    }
    $event.target.value = parseFloat(value).toFixed(this.decimalPlaces);
  }

  onDateChange(newDate: Date,controlName:string) {
    var control = this.formHelpersService.getControlFromGroup(this.formGroup,controlName);
    control.setValue(newDate)
  }

  typeChanged(){
    this.setDiscountInput('0');
  }

  startDateChanged(startDate:Date,endDateInput:any){
    var endDate = new Date(endDateInput.value)
    if(startDate>endDate){
      endDateInput.value = formatDate(startDate,'yyyy-MM-dd','en').toString()
    }
  }

  endDateChanged(endDate:Date,startDateInput:any){
    var startDate = new Date(startDateInput.value)
    if(startDate>endDate){
      startDateInput.value = formatDate(endDate,'yyyy-MM-dd','en').toString()
    }
  }

  remove(){
    var message='Do you want to remove this discount?'
    this.confirmService.confirm('',message).subscribe(result=>{
      if(result){
        var deletedControl = this.formHelpersService.getControlFromGroup(this.formGroup,'deleted');
        var idControl = this.formHelpersService.getControlFromGroup(this.formGroup,'id');
        if(idControl.value == '0'){
          this.removeEvent.emit(this.index)
        }
        else{
          deletedControl.setValue(true)
          this.deleted=true;
        }
      }
    })
  }

  asIsOrder(a:any, b:any) {
    return 1;
  }
}
