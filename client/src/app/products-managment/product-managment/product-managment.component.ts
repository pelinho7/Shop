import { AfterContentInit, Component, ComponentFactoryResolver, ComponentRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { forkJoin, Observable, ReplaySubject } from 'rxjs';
import { Photo } from 'src/app/_models/photo';
import { take } from 'rxjs/operators';
import { ProductService } from 'src/app/_services/product.service';
import { ProductDescriptionParagraphComponent } from '../product-description-paragraph/product-description-paragraph.component';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Product } from 'src/app/_models/product';
import { ToastrService } from 'ngx-toastr';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';
import { CategoryTreeItem } from 'src/app/_models/categoryTreeItem';
import { ProductCodeNotTaken } from 'src/app/validators/product-code-not-taken.validator';
import { FormHelpersService } from 'src/app/_services/form-helpers.service';
import { toInt } from 'ngx-bootstrap/chronos/utils/type-checks';

@Component({
  selector: 'app-product-managment',
  templateUrl: './product-managment.component.html',
  styleUrls: ['./product-managment.component.css']
})
export class ProductManagmentComponent implements OnInit {

  public photosSource: ReplaySubject<Photo[]> = new ReplaySubject<Photo[]>(1);
  @ViewChild("productDescriptionContainerRef", { read: ViewContainerRef })
  viewContainerRef: ViewContainerRef;

  categoryMap:Map<number, string>;
  showAttributesSection:boolean=false;
  stocksLevelsLoaded:boolean=false;
  productForm:FormGroup;
  dropzoneDisableClick:boolean=false;
  editMode:boolean=false;
  product:Product;
  child_unique_key: number = 0;
  componentsReferences = Array<ComponentRef<ProductDescriptionParagraphComponent>>()

  constructor(private componentFactoryResolver: ComponentFactoryResolver
    ,private productService:ProductService
    ,private router: Router
    ,private fb:FormBuilder
    ,private toastr:ToastrService
    ,public formHelpersService:FormHelpersService
    ,private categoryService:CategoryService) {
      this.productForm=this.fb.group({})
    }

    d:string=`<div>
    <div class="paragraph text-only">text</div>
    <div class="paragraph image-only">
       <div class="text-center"><img src="http://res.cloudinary.com/dcrajad97/image/upload/v1659549144/dlggj8es9ikrricvdk2m.jpg" class="w-100"/></div>
    </div>
    <div class="paragraph text-image">
       <div class="row">
          <div class="col-12 col-md-6">
             <div class="text-only">text im</div>
          </div>
          <div class="col-12 col-md-6">
             <div class="image-only">
                <div class="text-center"><img src="http://res.cloudinary.com/dcrajad97/image/upload/v1659549144/dlggj8es9ikrricvdk2m.jpg" class="w-100"/></div>
             </div>
          </div>
       </div>
    </div>
    <div class="paragraph image-text">
       <div class="row">
          <div class="col-12 col-md-6">
             <div class="image-only">
                <div class="text-center"><img src="http://res.cloudinary.com/dcrajad97/image/upload/v1659549144/dlggj8es9ikrricvdk2m.jpg" class="w-100"/></div>
             </div>
          </div>
          <div class="col-12 col-md-6">
             <div class="text-only">img-text</div>
          </div>
       </div>
    </div>
    <div class="paragraph image-image">
       <div class="row">
          <div class="col-12 col-md-6">
             <div class="image-only">
                <div class="text-center"><img src="http://res.cloudinary.com/dcrajad97/image/upload/v1659549144/dlggj8es9ikrricvdk2m.jpg" class="w-100"/></div>
             </div>
          </div>
          <div class="col-12 col-md-6">
             <div class="image-only">
                <div class="text-center"><img src="http://res.cloudinary.com/dcrajad97/image/upload/v1659549144/dlggj8es9ikrricvdk2m.jpg" class="w-100"/></div>
             </div>
          </div>
       </div>
    </div>
    </div>`


  ngAfterViewInit(): void {

  }

  loadDescription(){
    if(this.product.description!=null && this.product.description.length>0){
      var domparser = new DOMParser();
      var domdoc = domparser.parseFromString(this.product.description, 'text/xml');
      let elements = domdoc.querySelectorAll(".paragraph");
      //this.addDescriptionParagraph(false,elements[1]);
      elements.forEach(element => {
        this.addDescriptionParagraph(false,element);
      });
    }
    else{
      this.addDescriptionParagraph(false);
    }
  }

  addDescriptionParagraph(manualCreating:boolean=true,paragraphHtml:Element=null) {
    let componentFactory = this.componentFactoryResolver.resolveComponentFactory(ProductDescriptionParagraphComponent);

    let childComponentRef = this.viewContainerRef.createComponent(componentFactory);

    let childComponent = childComponentRef.instance;
    childComponent.unique_key = ++this.child_unique_key;
    childComponent.parentRef = this;

    if(!manualCreating){
      childComponentRef.changeDetectorRef.detectChanges();
    }
    if(paragraphHtml!=null){
      childComponent.setParagraphContent(paragraphHtml);
    }
    // add reference for newly created component
    this.componentsReferences.push(childComponentRef);
  }

  removeDescriptionParagraph(key: number) {
    if (this.viewContainerRef.length < 1) return;

    let componentRef = this.componentsReferences.filter(
      x => x.instance.unique_key == key
    )[0];
    componentRef.destroy();
    // removing component from the list
    this.componentsReferences = this.componentsReferences.filter(
      x => x.instance.unique_key !== key
    );
  }

  uploadImages(event:any){
    this.dragOver=false;
    this.productService.uploadImages(event.addedFiles).subscribe(addedPhotos=>{
      var currentPhotos:Photo[];
      this.photosSource.asObservable().pipe(take(1)).subscribe(p=>currentPhotos=p);
      currentPhotos.push(...addedPhotos);
      this.photosSource.next(currentPhotos);
      this.productService.productManagmentPhotos=currentPhotos;
    });
  }

  removeImage(photoId:number){
    this.productService.deletePhoto(photoId).subscribe(_=>{
      var currentPhotos:Photo[];
      this.photosSource.asObservable().pipe(take(1)).subscribe(p=>currentPhotos=p);
      currentPhotos = currentPhotos.filter(x=>x.id!=photoId);
      this.photosSource.next(currentPhotos);
      this.productService.productManagmentPhotos=currentPhotos;
    })
  }

  enableDropzoneClick(enable:boolean){
    this.dropzoneDisableClick=!enable;
  }

  reorderPhotos(event:any){
    var currentPhotos:Photo[];
    this.photosSource.asObservable().pipe(take(1)).subscribe(p=>currentPhotos=p);
    currentPhotos.splice(event.currentIndex,0,currentPhotos.splice(event.previousIndex,1)[0]);
    this.photosSource.next(currentPhotos);
    this.productService.productManagmentPhotos=currentPhotos;
  }

  dragOver:boolean=false;
  photoDragOver(event:any){
    this.dragOver=true;
  }

  photoDragOut(event:any){
    this.dragOver=false;
  }
  //attributesForm:FormGroup;
  categoryChanged(id:number){
    this.showAttributesSection=false;
    this.productService.getProductAttributes(id).subscribe(wrapper=>{
      let textControl = <FormArray>this.productForm.controls.textAttributes;
      let numberControl = <FormArray>this.productForm.controls.numberAttributes;
      textControl.clear();
      numberControl.clear();

      wrapper.productTextAttributes.forEach(attribute => {
        var group=this.fb.group(attribute);
        group.controls['value'].validator=Validators.required;
        textControl.push(group)
      });

      wrapper.productNumberAttributes.forEach(attribute => {
        var group=this.fb.group(attribute);
        group.controls['value'].validator=Validators.required;
        numberControl.push(group)
      });

      if((wrapper.productTextAttributes && wrapper.productTextAttributes.length>0)
      ||(wrapper.productNumberAttributes && wrapper.productNumberAttributes.length>0)){
        this.showAttributesSection=true;
      }
    })
  }

  ngOnInit(): void {
    var process$:Observable<[Product,CategoryTreeItem[]]>;
    if(this.router.url.toLocaleLowerCase().includes('edit')){
      var productId = this.router.url.split('/').pop();
      this.editMode=true;
      process$ = forkJoin(
        this.productService.getProduct(parseInt(productId)),
        this.categoryService.getCategories()
      );
    }
    else{
      process$ = forkJoin(
        this.productService.createProduct(),
        this.categoryService.getCategories()
      );
    }
    
    process$.subscribe(([product,category])=>{
      this.categoryMap=this.categoryService.categoryTree2Map(category,new Map<number, string>());
      this.product=product;

      if(this.editMode){
        product.description=this.d;
        this.photosSource.next(product.photos);
        this.productService.productManagmentPhotos=product.photos;
      }
      else{
        var p:Photo[]=[];
        this.photosSource.next(p);
      }
      this.createProductForm();
    });
  }

  dataLoaded:boolean=false;
  createProductForm(){
    this.editMode=false;
    this.productForm=this.fb.group({
      //id:[this.category.id,Validators.required],
      code:[{value: this.product.code, disabled: this.editMode},[Validators.required,Validators.maxLength(30)]],
      name:[this.product.name,[Validators.required,Validators.maxLength(60)]],
      categoryId:[{value: this.product.categoryId},Validators.required],
      textAttributes: this.fb.array([]),
      numberAttributes: this.fb.array([]),
      productAmounts: this.fb.array([])
    })

    if(!this.editMode){
      this.productForm.controls['code'].setAsyncValidators(ProductCodeNotTaken.createValidator(this.productService));
    }
    this.dataLoaded=true;
    this.loadDescription();
  }

  stocksLevelsTabSelected(){
    if(!this.stocksLevelsLoaded){
      this.productService.getProductAmounts(this.product.id).subscribe(amounts=>{
        this.stocksLevelsLoaded=true;
        this.product.productAmounts=amounts;

      let amountsControl = <FormArray>this.productForm.controls.productAmounts;
      amountsControl.clear();

      this.product.productAmounts.forEach(amount => {
        var group=this.fb.group(amount);
        group.controls['amount'].validator=Validators.required;
        group.controls['amount'].setValue(amount.amount);
        amountsControl.push(group)
      });
      })
    }
  }

  saveProduct(){
    try{
      console.log(this.productForm.value)
return;
      this.componentsReferences.forEach(component => {
        var content = component.instance.getParagraphContent();
        console.log(content)
      });
    }
    catch(e){
      this.toastr.error((<Error>e).message);
      return;
    }
    
  }

}
