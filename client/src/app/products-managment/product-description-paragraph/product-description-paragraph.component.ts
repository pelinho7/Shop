import { AfterViewInit, Component, ElementRef, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { ProductManagmentComponent } from '../product-managment/product-managment.component';

@Component({
  selector: 'app-product-description-paragraph',
  templateUrl: './product-description-paragraph.component.html',
  styleUrls: ['./product-description-paragraph.component.css']
})
export class ProductDescriptionParagraphComponent implements AfterViewInit {
  public unique_key: number;
  public parentRef: ProductManagmentComponent;
  htmlParagraph:string;
  paragraphType:ParagraphType=ParagraphType.TextOnly
  public ParagraphType: typeof ParagraphType = ParagraphType;

  @ViewChild('paragraphBody') paragraphBodyDiv:ElementRef;

  constructor(private elRef:ElementRef) { }

  ngOnInit(): void {
    
  }

  ngAfterViewInit() {
    this.textOnly();
  }

  choosePicture(){
    console.log("dsadsa")
  }

  remove() {
    this.parentRef.removeDescriptionParagraph(this.unique_key)
  }

  setStartupParagraphContent(html:string){
    //remove previous content
    if(this.paragraphBodyDiv.nativeElement.children.length>0){
      this.paragraphBodyDiv.nativeElement.children[0].remove();
    }
    //add new paragraph content
    this.paragraphBodyDiv.nativeElement.insertAdjacentHTML('beforeend', html);
  }

  textOnly(){
    this.paragraphType=ParagraphType.TextOnly;
    var html = `<div class="text-only" style="height: 100px;"></div>`;

    this.setStartupParagraphContent(html);
  }

  imageOnly(){
    this.paragraphType=ParagraphType.ImageOnly;

    var html = `
    <div class="text-center image-only">
    <img src="/assets/images/empty image.png"/>
    </div>`;

    this.setStartupParagraphContent(html);

    this.elRef.nativeElement.querySelector('.image-only')
      .addEventListener('click', this.choosePicture.bind(this));
  }

  textImage(){
    this.paragraphType=ParagraphType.TextImage;

    var html =`    
    <div class="row text-image">
    <div class="col-12 col-sm-6"></div>
    <div class="col-12 col-sm-6 text-center">
      <img src="/assets/images/empty image.png"/>
    </div>
  </div>`

  this.setStartupParagraphContent(html);
  }

  imageText(){
    this.paragraphType=ParagraphType.ImageText;
  }

  imageImage(){
    this.paragraphType=ParagraphType.ImageImage;
  }
}

enum ParagraphType { TextOnly = 1, ImageOnly=2, TextImage = 3, ImageText = 4, ImageImage=5 }; 