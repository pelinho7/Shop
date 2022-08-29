import { AfterViewInit, ChangeDetectionStrategy, Component, ComponentFactoryResolver, ElementRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { ProductManagmentComponent } from '../product-managment/product-managment.component';
import { ImageImageParagraphTypeComponent } from './paragraph-types/image-image-paragraph-type/image-image-paragraph-type.component';
import { ImageOnlyParagraphTypeComponent } from './paragraph-types/image-only-paragraph-type/image-only-paragraph-type.component';
import { ImageTextParagraphTypeComponent } from './paragraph-types/image-text-paragraph-type/image-text-paragraph-type.component';
import { TextImageParagraphTypeComponent } from './paragraph-types/text-image-paragraph-type/text-image-paragraph-type.component';
import { TextOnlyParagraphTypeComponent } from './paragraph-types/text-only-paragraph-type/text-only-paragraph-type.component';

@Component({
  selector: 'app-product-description-paragraph',
  templateUrl: './product-description-paragraph.component.html',
  styleUrls: ['./product-description-paragraph.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductDescriptionParagraphComponent implements OnInit {
  public unique_key: number;
  public parentRef: ProductManagmentComponent;
  htmlParagraph:string;
  paragraphType:ParagraphType=null;
  public ParagraphType: typeof ParagraphType = ParagraphType;

  @ViewChild('paragraphBody') paragraphBodyDiv:ElementRef;

  @ViewChild(TextOnlyParagraphTypeComponent) textOnlyParagraph:TextOnlyParagraphTypeComponent;
  @ViewChild(ImageOnlyParagraphTypeComponent,{static:false}) imageOnlyParagraph:ImageOnlyParagraphTypeComponent;
  @ViewChild(TextImageParagraphTypeComponent) textImageParagraph:TextImageParagraphTypeComponent;
  @ViewChild(ImageTextParagraphTypeComponent) imageTextParagraph:ImageTextParagraphTypeComponent;
  @ViewChild(ImageImageParagraphTypeComponent) imageImageParagraph:ImageImageParagraphTypeComponent;
 

  componentsReference :any;
  @ViewChild("paragraphBodyContainerRef", { read: ViewContainerRef })
  viewContainerRef: ViewContainerRef;
  
  constructor(private eRef: ElementRef
    ,private componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.textOnly();
  }

  choosePicture(){
    console.log("dsadsa")
  }

  remove() {
    this.parentRef.removeDescriptionParagraph(this.unique_key)
  }

  textOnly(){
    this.paragraphType=ParagraphType.TextOnly;
  }

  imageOnly(){
    this.paragraphType=ParagraphType.ImageOnly;
  }

  textImage(){
    this.paragraphType=ParagraphType.TextImage;
  }

  imageText(){
    this.paragraphType=ParagraphType.ImageText;
  }

  imageImage(){
    this.paragraphType=ParagraphType.ImageImage;
  }

  getParagraphContent(){
    var content='';
    if(this.paragraphType==ParagraphType.TextOnly){
      var content = this.textOnlyParagraph.getParagraphContent();
    }
    else if(this.paragraphType==ParagraphType.ImageOnly){
      var content = this.imageOnlyParagraph.getParagraphContent();
    }
    else if(this.paragraphType==ParagraphType.TextImage){
      var content = this.textImageParagraph.getParagraphContent();
    }
    else if(this.paragraphType==ParagraphType.ImageText){
      var content = this.imageTextParagraph.getParagraphContent();
    }
    else if(this.paragraphType==ParagraphType.ImageImage){
      var content = this.imageImageParagraph.getParagraphContent();
    }
    return content;
  }

  setParagraphContent(paragraphHtml:Element){
    if(paragraphHtml.classList.contains('text-only')){
      this.textOnly();
      this.textOnlyParagraph.setParagraphContent(paragraphHtml);
    }
    else if(paragraphHtml.classList.contains('image-only')){
      this.imageOnly();
      this.imageOnlyParagraph.setParagraphContent(paragraphHtml);
    }
    else if(paragraphHtml.classList.contains('text-image')){
      this.textImage();
      this.textImageParagraph.setParagraphContent(paragraphHtml);
    }
    else if(paragraphHtml.classList.contains('image-text')){
      this.imageText();
      this.imageTextParagraph.setParagraphContent(paragraphHtml);
    }
    else if(paragraphHtml.classList.contains('image-image')){
      this.imageImage();
      this.imageImageParagraph.setParagraphContent(paragraphHtml);
    }
  }
}

enum ParagraphType { TextOnly = 1, ImageOnly=2, TextImage = 3, ImageText = 4, ImageImage=5 }; 