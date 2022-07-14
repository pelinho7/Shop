import { Component, ComponentFactoryResolver, ComponentRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { ProductDescriptionParagraphComponent } from '../product-description-paragraph/product-description-paragraph.component';

@Component({
  selector: 'app-product-managment',
  templateUrl: './product-managment.component.html',
  styleUrls: ['./product-managment.component.css']
})
export class ProductManagmentComponent implements OnInit {

  @ViewChild("productDescriptionContainerRef", { read: ViewContainerRef })
  viewContainerRef: ViewContainerRef;

  child_unique_key: number = 0;
  componentsReferences = Array<ComponentRef<ProductDescriptionParagraphComponent>>()

  constructor(private componentFactoryResolver: ComponentFactoryResolver) {}

  addDescriptionParagraph() {
    let componentFactory = this.componentFactoryResolver.resolveComponentFactory(ProductDescriptionParagraphComponent);

    let childComponentRef = this.viewContainerRef.createComponent(componentFactory);

    let childComponent = childComponentRef.instance;
    childComponent.unique_key = ++this.child_unique_key;
    childComponent.parentRef = this;

    // add reference for newly created component
    this.componentsReferences.push(childComponentRef);
  }

  removeDescriptionParagraph(key: number) {
    console.log(key)
    if (this.viewContainerRef.length < 1) return;

    let componentRef = this.componentsReferences.filter(
      x => x.instance.unique_key == key
    )[0];
    componentRef.destroy();
    // removing component from the list
    this.componentsReferences = this.componentsReferences.filter(
      x => x.instance.unique_key !== key
    );

    // let vcrIndex: number = this.viewContainerRef.indexOf(componentRef as any);
    // console.log(this.viewContainerRef)
    // console.log(componentRef)
    // // removing component from container
    // this.viewContainerRef.remove(vcrIndex);

    // // removing component from the list
    // this.componentsReferences = this.componentsReferences.filter(
    //   x => x.instance.unique_key !== key
    // );
  }

  ngOnInit(): void {
  }

}
