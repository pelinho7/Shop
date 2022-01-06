import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-checkbox-input',
  templateUrl: './checkbox-input.component.html',
  styleUrls: ['./checkbox-input.component.css']
})

export class CheckboxInputComponent implements ControlValueAccessor,OnInit {
  @Input() contents:string;
  displayedContents:string;
  overflowContents:boolean=false;
  maxContentsLength:number=100;
  constructor(@Self() public ngControl: NgControl) { 
    
    this.ngControl.valueAccessor=this;
  }

  ngOnInit(): void {
    this.displayedContents=this.contents;
    if(this.contents.length>this.maxContentsLength){
      this.displayedContents=this.contents.substring(0,this.maxContentsLength)+'...';
      this.overflowContents=true;
    }
  }

  moreLess(event:PointerEvent){
    if(this.displayedContents===this.contents){
      this.displayedContents=this.contents.substring(0,this.maxContentsLength)+'...';
      
    }
    else{
      this.displayedContents=this.contents;
      (event.target as Element).innerHTML='Less';
    }
    console.log((event.target as Element).innerHTML)
    console.log((event))
  }

  change(){
    console.log(this.ngControl.control?.errors?.required)
  }

  writeValue(obj: any): void {
  }
  registerOnChange(fn: any): void {
  }
  registerOnTouched(fn: any): void {
  }

}

