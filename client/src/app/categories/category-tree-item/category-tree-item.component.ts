import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CategoryTreeItem } from 'src/app/_models/categoryTreeItem';

@Component({
  selector: 'app-category-tree-item',
  templateUrl: './category-tree-item.component.html',
  styleUrls: ['./category-tree-item.component.css']
})
export class CategoryTreeItemComponent implements OnInit {

  @Input() categoryTreeItem:CategoryTreeItem;
  @Output() addEvent = new EventEmitter<number>();
  @Output() editEvent = new EventEmitter<number>();
  @Output() deleteEvent = new EventEmitter<number>();
  @Output() showHistoryEvent = new EventEmitter<number>();
  @Output() expandReduceEvent = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }

  add(id:number){
    this.addEvent.emit(id);
  }
  
  edit(id:number){
    this.editEvent.emit(id);
  }

  delete(id:number){
    this.deleteEvent.emit(id);
  }

  showHistory(id:number){
    this.showHistoryEvent.emit(id);
  }

  expandReduce(id:number){
    this.expandReduceEvent.emit(id);
  }
}
