import { AfterContentInit, Component, ComponentFactoryResolver, ComponentRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { forkJoin, Observable, of, ReplaySubject } from 'rxjs';
import { Photo } from 'src/app/_models/photo';
import { filter, take } from 'rxjs/operators';
import { ProductService } from 'src/app/_services/product.service';
import { ProductDescriptionParagraphComponent } from '../product-description-paragraph/product-description-paragraph.component';
import { ActivatedRoute, NavigationEnd, Route, Router } from '@angular/router';
import { Product } from 'src/app/_models/product';
import { ToastrService } from 'ngx-toastr';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { CategoryService } from 'src/app/_services/category.service';
import { CategoryTreeItem } from 'src/app/_models/categoryTreeItem';
import { ProductCodeNotTaken } from 'src/app/validators/product-code-not-taken.validator';
import { FormHelpersService } from 'src/app/_services/form-helpers.service';
import { toInt } from 'ngx-bootstrap/chronos/utils/type-checks';
import { Discount } from 'src/app/_models/discount';
import { formatDate } from '@angular/common';
import { getUsersLocale } from 'src/app/_helpers/historyHelpers';
import { ProductUpsert } from 'src/app/_models/productUpsert';
import { ConfirmService } from 'src/app/_services/confirm.service';
import { ProductAttributesWrapper } from 'src/app/_models/productAttributesWrapper';
import { ProductManagmentService } from 'src/app/_services/product-managment.service';
import { UrlService } from 'src/app/_services/url.service';

@Component({
  selector: 'app-product-managment',
  templateUrl: './product-managment.component.html',
  styleUrls: ['./product-managment.component.css']
})
export class ProductManagmentComponent implements OnInit {

  public photosSource: ReplaySubject<Photo[]> = new ReplaySubject<Photo[]>(1);
  @ViewChild("productDescriptionContainerRef", { read: ViewContainerRef })
  viewContainerRef: ViewContainerRef;

  public discountsSource: ReplaySubject<Discount[]> = new ReplaySubject<Discount[]>(1);

  categoryMap: Map<number, string>;
  showAttributesSection: boolean = false;
  stocksLevelsLoaded: boolean = false;
  discountsLoaded: boolean = false;
  productForm: FormGroup;
  dropzoneDisableClick: boolean = false;
  editMode: boolean = false;
  product: ProductUpsert;
  child_unique_key: number = 0;
  componentsReferences = Array<ComponentRef<ProductDescriptionParagraphComponent>>()

  constructor(private componentFactoryResolver: ComponentFactoryResolver
    , private productService: ProductManagmentService
    , private router: Router
    , private fb: FormBuilder
    , private toastr: ToastrService
    , public formHelpersService: FormHelpersService
    , private categoryService: CategoryService
    , private confirmService: ConfirmService
    , private urlService: UrlService) {
    this.productForm = this.fb.group({});
  }

  d: string = `<div>
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

  loadDescription() {
    if (this.product.description != null && this.product.description.length > 0) {
      var domparser = new DOMParser();
      var domdoc = domparser.parseFromString(this.product.description, 'text/xml');
      let elements = domdoc.querySelectorAll(".paragraph");
      //this.addDescriptionParagraph(false,elements[1]);
      elements.forEach(element => {
        this.addDescriptionParagraph(false, element);
      });
    }
    else {
      this.addDescriptionParagraph(false);
    }
  }

  addDescriptionParagraph(manualCreating: boolean = true, paragraphHtml: Element = null) {
    let componentFactory = this.componentFactoryResolver.resolveComponentFactory(ProductDescriptionParagraphComponent);

    let childComponentRef = this.viewContainerRef.createComponent(componentFactory);

    let childComponent = childComponentRef.instance;
    childComponent.unique_key = ++this.child_unique_key;
    childComponent.parentRef = this;

    if (!manualCreating) {
      childComponentRef.changeDetectorRef.detectChanges();
    }
    if (paragraphHtml != null) {
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

  uploadImages(event: any) {
    this.dragOver = false;
    this.productService.uploadImages(event.addedFiles, this.product.id).subscribe(addedPhotos => {
      var currentPhotos: Photo[];
      this.photosSource.asObservable().pipe(take(1)).subscribe(p => currentPhotos = p);
      currentPhotos.push(...addedPhotos);
      this.photosSource.next(currentPhotos);
      this.productService.productManagmentPhotos = currentPhotos;
    });
  }

  removeImage(photoId: number) {
    this.productService.deletePhoto(photoId).subscribe(_ => {
      var currentPhotos: Photo[];
      this.photosSource.asObservable().pipe(take(1)).subscribe(p => currentPhotos = p);
      currentPhotos = currentPhotos.filter(x => x.id != photoId);
      this.photosSource.next(currentPhotos);
      this.productService.productManagmentPhotos = currentPhotos;
    })
  }

  enableDropzoneClick(enable: boolean) {
    this.dropzoneDisableClick = !enable;
  }

  reorderPhotos(event: any) {
    var currentPhotos: Photo[];
    this.photosSource.asObservable().pipe(take(1)).subscribe(p => currentPhotos = p);
    currentPhotos.splice(event.currentIndex, 0, currentPhotos.splice(event.previousIndex, 1)[0]);
    this.photosSource.next(currentPhotos);
    this.productService.productManagmentPhotos = currentPhotos;
  }

  dragOver: boolean = false;
  photoDragOver(event: any) {
    this.dragOver = true;
  }

  photoDragOut(event: any) {
    this.dragOver = false;
  }

  setProductAttrinutesIntoForm(wrapper: ProductAttributesWrapper) {
    let textControl = <FormArray>this.productForm.controls.textAttributes;
    let numberControl = <FormArray>this.productForm.controls.numberAttributes;
    textControl.clear();
    numberControl.clear();

    wrapper.productTextAttributes.forEach(attribute => {
      var group = this.fb.group(attribute);
      group.controls['value'].validator = Validators.required;
      group.controls['value'].setValue(attribute.value);
      textControl.push(group)
    });

    wrapper.productNumberAttributes.forEach(attribute => {
      var group = this.fb.group(attribute);
      group.controls['value'].validator = Validators.required;
      group.controls['value'].setValue(attribute.value);
      numberControl.push(group)
    });

    if ((wrapper.productTextAttributes && wrapper.productTextAttributes.length > 0)
      || (wrapper.productNumberAttributes && wrapper.productNumberAttributes.length > 0)) {
      this.showAttributesSection = true;
    }
  }

  categoryChanged(id: number) {
    this.showAttributesSection = false;
    this.productService.getProductAttributes(id, this.product.id).subscribe(wrapper => {
      this.setProductAttrinutesIntoForm(wrapper);
    })
  }

  ngOnInit(): void {
    var process$: Observable<[ProductUpsert, CategoryTreeItem[]]>;
    //var getProductAttributes = (categoryId:number) => { return of(null);};  
    if (this.router.url.toLocaleLowerCase().includes('edit')) {
      var productId = this.router.url.split('/').pop();
      this.editMode = true;

      process$ = forkJoin(
        this.productService.getUpsertProduct(parseInt(productId)),
        this.categoryService.getCategories()
      );
    }
    else {
      process$ = forkJoin(
        this.productService.createProduct(),
        this.categoryService.getCategories()
      );
    }

    process$.subscribe(([product, category]) => {
      this.categoryMap = this.categoryService.categoryTree2Map(category, new Map<number, string>());
      this.product = product;

      if (this.editMode) {
        //product.description=this.d;
        //add parent div to entire description
        product.description = '<div>' + product.description + '</div>'
        this.photosSource.next(product.photos);
        this.productService.productManagmentPhotos = product.photos;
      }
      else {
        var p: Photo[] = [];
        this.photosSource.next(p);
      }
      this.createProductForm();
    });
  }

  dataLoaded: boolean = false;
  createProductForm() {
    this.productForm = this.fb.group({
      id: [this.product.id],
      code: [{ value: this.product.code, disabled: this.editMode }, [Validators.required, Validators.maxLength(30)]],
      name: [this.product.name, [Validators.required, Validators.maxLength(60)]],
      categoryId: [this.product.categoryId, Validators.required],
      price: [this.product.price, [Validators.required, , Validators.min(0.01)]],
      textAttributes: this.fb.array([]),
      numberAttributes: this.fb.array([]),
      productAmounts: this.fb.array([]),
      productDiscounts: this.fb.array([])
    })

    if (!this.editMode) {
      this.productForm.controls['code'].setAsyncValidators(ProductCodeNotTaken.createValidator(this.productService));
    }

    if (this.product.categoryId && this.product.categoryId > 0) {
      this.categoryChanged(this.product.categoryId)
    }

    this.dataLoaded = true;
    this.loadDescription();
  }

  stocksLevelsTabSelected() {
    if (!this.stocksLevelsLoaded) {
      this.productService.getProductAmounts(this.product.id).subscribe(amounts => {
        this.stocksLevelsLoaded = true;
        this.product.productAmounts = amounts;

        let amountsControl = <FormArray>this.productForm.controls.productAmounts;
        amountsControl.clear();

        this.product.productAmounts.forEach(amount => {
          var group = this.fb.group(amount);
          group.controls['amount'].validator = Validators.required;
          group.controls['amount'].setValue(amount.amount);
          amountsControl.push(group)
        });
      })
    }
  }

  discountsTabSelected() {
    if (!this.discountsLoaded) {
      this.productService.getProductDiscounts(this.product.id).subscribe(discounts => {
        this.discountsLoaded = true;
        let discountsControl = <FormArray>this.productForm.controls.productDiscounts;
        discountsControl.clear();

        discounts.forEach(discount => {
          this.addDiscountControlsToForm(discount, discountsControl);
        });

        //this.discountsSource.next(currentDiscounts);
      })

    }
  }

  datePickerConfig = {
    dateInputFormat: 'YYYY-MM-DD',
    isAnimated: true,
    adaptivePosition: true
  };
  onDateChange(newDate: Date, a: FormControl) {
    a.setValue(newDate)
  }

  addDiscountControlsToForm(discount: Discount, discountsControl: FormArray<any>) {
    (discount as Discount).startDateString = formatDate(discount.startDate, 'yyyy-MM-dd', 'en').toString();
    (discount as Discount).endDateString = formatDate(discount.endDate, 'yyyy-MM-dd', 'en').toString();
    var group = this.fb.group(discount);
    group.controls['value'].validator = Validators.required;
    group.controls['value'].setValue(discount.value);
    group.controls['startDateString'].setValue(discount.startDateString);
    group.controls['endDateString'].setValue(discount.endDateString);

    discountsControl.push(group)
  }

  removeDiscountControlsFromForm() {

  }

  addDiscount() {
    var discount = new Discount();
    discount.productId = this.product.id;
    this.addDiscountControlsToForm(new Discount(), <FormArray>this.productForm.controls.productDiscounts)
  }

  removeDiscount(index: number) {
    let discountsControl = <FormArray>this.productForm.controls.productDiscounts;
    discountsControl.removeAt(index)
  }

  saveProduct() {
    // this.router.navigateByUrl(this.urlService.getPreviousUrl())
    // return;
    try {
      if (this.productForm.value.productDiscounts && this.productForm.value.productDiscounts.length > 0
        && this.productForm.value.productDiscounts.filter((x: Discount) => x.value == 0 && !x.deleted).length > 0) {
        this.confirmService.confirm('', 'Discouts list contains items with 0 value. They will by skipped. Do you want to continue?')
          .subscribe(result => {
            if (!result) {
              return;
            }
          })
      }
      var description = '';
      this.componentsReferences.forEach(component => {
        description += component.instance.getParagraphContent();
      });

      var productUpsert = this.productForm.value as ProductUpsert
      productUpsert.description = description;
      this.productService.updateProduct(productUpsert).subscribe(_ => {
        if (this.editMode) {
          //when category is not changed filter on list page fit
          if (productUpsert.categoryId == this.product.categoryId) {
            this.router.navigateByUrl(this.urlService.getPreviousUrl())
          }
          else {
            //force to reload list
            this.productService.resetCashedData();
            this.router.navigateByUrl('/products-managment')
          }
        }
        else {
          //force to reload list
          this.productService.resetCashedData();
          this.router.navigateByUrl('/products-managment')
        }
      })
    }
    catch (e) {
      console.log((<Error>e).stack)
      this.toastr.error((<Error>e).message);
      return;
    }

  }

}
