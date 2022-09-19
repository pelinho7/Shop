import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CategoryTreeItem } from 'src/app/_models/categoryTreeItem';

@Component({
  selector: 'app-side-navbar-item',
  templateUrl: './side-navbar-item.component.html',
  styleUrls: ['./side-navbar-item.component.css']
})
export class SideNavbarItemComponent implements OnInit {

  @Input() categoryTreeItem:CategoryTreeItem;
  @Output() expandReduceEvent = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }

  expandReduce(id:number){
    this.expandReduceEvent.emit(id);
  }

}
