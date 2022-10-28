import { Component, EventEmitter, HostListener, Input, OnInit, Output } from '@angular/core';
import { FilterAttribute } from 'src/app/_models/filterAttribute';
import { ProductsFilterService } from 'src/app/_services/products-filter.service';

@Component({
  selector: 'app-products-filter',
  templateUrl: './products-filter.component.html',
  styleUrls: ['./products-filter.component.css']
})
export class ProductsFilterComponent implements OnInit {

  submitBtnStyles = new Map<string, string>();

  @HostListener('window:resize', ['$event'])onResize($event:any) {
    var mainPanel =document.getElementById('form-main-panel');
    var buttonWidth = mainPanel?.getBoundingClientRect().width;
    this.submitBtnStyles.set('width',buttonWidth+'px');
    this.closeFilterPanel();
  }

  @HostListener('window:scroll', ['$event']) onScrollEvent($event:any){
    const winScrollTop = window.pageYOffset 
    || document.documentElement.scrollTop 
    || document.body.scrollTop || 0;

    var mainPanel =document.getElementById('form-main-panel');
    var mainPanelHeight = mainPanel?.getBoundingClientRect().height

    let position:string='relative';

    this.submitBtnStyles.set('position',position);
    this.submitBtnStyles.set('top',Math.min(<number>mainPanelHeight,winScrollTop)+'px');
  } 

  @Input('filterAttributes') filterAttributes: FilterAttribute[];
  @Output() filter: EventEmitter<any> = new EventEmitter();
  visibleChecks=2; 
  constructor(public productsFilterService:ProductsFilterService) { }

  ngOnInit(): void {
    var mainPanel =document.getElementById('form-main-panel');
    var buttonWidth = mainPanel?.getBoundingClientRect().width
    this.submitBtnStyles.set('width',buttonWidth+'px');
  }

  filterProducts(){
    this.filter.emit(null);
  }

  closeFilterPanel(){
    (document.querySelector('#filter-products-panel') as HTMLElement).style.width = '0%';
    var topNav=(document.querySelector('#top-navbar') as HTMLElement);
    topNav.style.zIndex='';
  }

  moreCheckboxes(event:any){
    //get all hidden checks
    var notDisplayChecks:any[]=event.srcElement.parentElement.querySelectorAll('.d-none');
    //if exists hidden checks remove d-none class
    if(notDisplayChecks?.length>0){
      event.srcElement.innerText='Less';
      notDisplayChecks.forEach(x=>{
        x.classList.remove("d-none");
      })
    }
    else{
      //get all checks
      event.srcElement.innerText='More';
      var allChecks:any[]=event.srcElement.parentElement.querySelectorAll('.form-check');
      //add d-none class to extra checks
      for (let i = 0; i < allChecks.length; i++) {
        if(i<this.visibleChecks)continue;
        allChecks[i].classList.add("d-none");
      }
    }
  }

}
