import { ChangeDetectionStrategy, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { removeAngularTags } from 'src/app/_helpers/descriptionParagraphHelpers';
import { ProductImagesPickerComponent } from '../../product-images-picker/product-images-picker.component';

@Component({
  selector: 'app-image-only-paragraph-type',
  templateUrl: './image-only-paragraph-type.component.html',
  styleUrls: ['./image-only-paragraph-type.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ImageOnlyParagraphTypeComponent implements OnInit {

  bsModalRef?: BsModalRef;

  constructor(private modalService: BsModalService
    ,private element: ElementRef) { }

  ngOnInit(): void {
  }

  selectPhoto(){
    const initialState: ModalOptions = {
      initialState: {
      },
      class:'modal-lg'
    };
    this.bsModalRef = this.modalService.show(ProductImagesPickerComponent,initialState);
    this.bsModalRef.content.closeBtnName = 'Close'
    this.bsModalRef.onHidden.subscribe(()=>{
      //change of image src
      if(this.bsModalRef.content.selectedUrl.length>0){
        var img = this.element.nativeElement.querySelector('img');
        img.src=this.bsModalRef.content.selectedUrl
        img.classList.add("w-100");
      }
    });
  }

  

  getParagraphContent(mainElement:boolean=true){
    var img = this.element.nativeElement.querySelector('img');
    if(img.src.includes(encodeURI("/assets/images/empty image.png"))){
      throw new Error('Please set image in description paragraph or remove it.')
    }

    var html = removeAngularTags(this.element.nativeElement.querySelector('div').outerHTML)
    html = html.replace('></div>','/></div>');

    var containter='';
    if(mainElement){
      containter='<div class="paragraph image-only">'
    }
    else{
      containter='<div class="image-only">'
    }
    return containter+html+'</div>';
  }

  setParagraphContent(paragraphHtml:Element){
    var src = paragraphHtml.querySelector('img').getAttribute('src');
    var img = this.element.nativeElement.querySelector('img');
    img.src=src;
    img.classList.add("w-100");
  }
}
