import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { CategoryCodeNotTaken } from 'src/app/validators/category-code-not-taken.validator';
import { Category } from 'src/app/_models/category';
import { AttributeService } from 'src/app/_services/attribute.service';
import { CategoryService } from 'src/app/_services/category.service';
import { Attribute } from 'src/app/_models/attribute';
import { ReplaySubject, Subject } from 'rxjs';
import { take, takeUntil } from 'rxjs/operators';
import { CategoryAttribute } from 'src/app/_models/categoryAttribute';
import { MatSelect } from '@angular/material/select';
import { MatOption } from '@angular/material/core';

@Component({
  selector: 'app-upsert-category',
  templateUrl: './upsert-category.component.html',
  styleUrls: ['./upsert-category.component.css']
})
export class UpsertCategoryComponent implements OnInit {

  title?: string="New category";
  attributes:Attribute[];
  attributesSelectArray:Attribute[];
  category:Category;
  categoryForm:FormGroup;
  selectedType:number;
  filtrationModesArray = new Map<number, string>();
  filtrationModeVisibile:boolean=false;
  public editMode:boolean=false;
  saved:boolean=false;
  @ViewChild('matSelectRef') matSelectRef: MatSelect;

  
  /** Subject that emits when the component has been destroyed. */
  protected _onDestroy = new Subject<void>();
  public filteredAttributes: ReplaySubject<Attribute[]> = new ReplaySubject<Attribute[]>(1);

  public categoryAttributes: ReplaySubject<CategoryAttribute[]> = new ReplaySubject<CategoryAttribute[]>(1);
 
  constructor(public bsModalRef: BsModalRef,private fb:FormBuilder
    ,private toastr:ToastrService,private attributeService:AttributeService
    ,private categoryService:CategoryService) {}

  ngOnInit(): void {
    this.categoryAttributes.next(this.category.categoryAttributes);
    this.attributes= this.filterAddedAttributes(this.category.parentCategoriesAttributes.map(z=>z.attributeId));
    console.log(this.category.parentCategoriesAttributes)
    this.attributesSelectArray=this.attributes;

    if(this.category.id>0){
      this.title="Edit category";
      this.title="Edit "+this.category.code+" attribute";
      this.editMode=true;
    }

    this.categoryForm=this.fb.group({
      id:[this.category.id,Validators.required],
      parentCategoryId:[this.category.parentCategoryId],
      code:[{value: this.category.code, disabled: this.editMode},[Validators.required,Validators.maxLength(30)]],
      label:[this.category.label,[Validators.required,Validators.maxLength(60)]],
      deleted:[this.category.deleted],
      filteredAttributes:[],
      attributes:[this.attributes],
      categoryAttributes:[this.category.categoryAttributes],
    })
    if(!this.editMode){
      this.categoryForm.controls['code'].setAsyncValidators(CategoryCodeNotTaken.createValidator(this.categoryService));
    }

    // load the initial attributes list
    this.filteredAttributes.next(this.attributes.slice());

    // listen for search field value changes
    this.categoryForm.controls['filteredAttributes'].valueChanges
      .pipe(takeUntil(this._onDestroy))
      .subscribe(() => {
        this.filterAttributes();
      });
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
  }

  addCategoryAttribute(categoryId:number){
    if(categoryId===undefined){
      return;
    }
    var selectedAttribute=this.attributes.find(x=>x.id==categoryId)

    var  categoryAttributesArray:CategoryAttribute[]=[];
    this.categoryAttributes.asObservable().pipe(take(1)).subscribe(a=>categoryAttributesArray=a);
    var categoryAttribute: CategoryAttribute = { id:0,attributeId:selectedAttribute.id,categoryId: categoryId, code: selectedAttribute.code, lp:0 }
    categoryAttributesArray.push(categoryAttribute)
    this.categoryAttributes.next(categoryAttributesArray);
    this.matSelectRef.options.forEach((data: MatOption) => data.deselect());

    this.removeAddedAttributesFromSelectList(categoryAttributesArray.map(x=>x.categoryId));
  }

  filterAddedAttributes(ids:number[]){
    return this.attributes.filter(x=>!ids.includes(x.id));
  }

  drop(e:any){
    var  categoryAttributesArray:CategoryAttribute[]=[];
    this.categoryAttributes.asObservable().pipe(take(1)).subscribe(a=>categoryAttributesArray=a);
    //reorder elements in list
    var element = categoryAttributesArray[e.previousIndex];
    categoryAttributesArray.splice(e.previousIndex, 1);
    categoryAttributesArray.splice(e.currentIndex, 0, element);
  }

  removeAddedAttributesFromSelectList(ids:number[]){
    this.attributesSelectArray=this.filterAddedAttributes(ids);
    this.filteredAttributes.next(this.attributesSelectArray);
  }

  removeCategoryAttribute(attributeId:number){
    console.log(attributeId)
    var  categoryAttributesArray:CategoryAttribute[]=[];
    this.categoryAttributes.asObservable().pipe(take(1)).subscribe(a=>categoryAttributesArray=a);
    categoryAttributesArray = categoryAttributesArray.filter(x=>x.attributeId!=attributeId)
    this.categoryAttributes.next(categoryAttributesArray);

    this.removeAddedAttributesFromSelectList(categoryAttributesArray.map(x=>x.attributeId));
  }

  protected filterAttributes() {
    if (!this.attributesSelectArray) {
      return;
    }
    // get the search keyword
    let search = this.categoryForm.controls['filteredAttributes'].value;
    if (!search) {
      this.filteredAttributes.next(this.attributesSelectArray.slice());
      return;
    } else {
      search = search.toLowerCase();
    }
    // filter attributes
    this.filteredAttributes.next(
      this.attributesSelectArray.filter(x => x.code.toLowerCase().indexOf(search) > -1)
    );
  }

  save(){
    var cat=this.categoryForm.value as Category;

    this.categoryAttributes.asObservable().pipe(take(1)).subscribe(a=>cat.categoryAttributes=a);
      cat.categoryAttributes.forEach((categoryAttribute, index) => {
      categoryAttribute.lp=index+1;
    });

    this.categoryService.upsertCategory(cat).subscribe((category:any)=>{
      if(this.editMode){
        this.toastr.info('Category edited')
      }
      else{
        this.toastr.info('Category added')
      }
      this.categoryService
      this.saved=true;
      this.bsModalRef.hide();
    })
  }

}
