import { ChangeDetectionStrategy, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { removeAngularTags } from 'src/app/_helpers/descriptionParagraphHelpers';
import { ImageOnlyParagraphTypeComponent } from '../image-only-paragraph-type/image-only-paragraph-type.component';
import { TextOnlyParagraphTypeComponent } from '../text-only-paragraph-type/text-only-paragraph-type.component';

@Component({
  selector: 'app-image-text-paragraph-type',
  templateUrl: './image-text-paragraph-type.component.html',
  styleUrls: ['./image-text-paragraph-type.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ImageTextParagraphTypeComponent implements OnInit {
  @ViewChild(ImageOnlyParagraphTypeComponent) imageOnlyParagraph:ImageOnlyParagraphTypeComponent;
  @ViewChild(TextOnlyParagraphTypeComponent) textOnlyParagraph:TextOnlyParagraphTypeComponent;

  constructor(private element: ElementRef) { }

  ngOnInit(): void {
  }

  getParagraphContent(){
    var imageContent = this.imageOnlyParagraph.getParagraphContent(false);
    var textContent = this.textOnlyParagraph.getParagraphContent(false);

    // this.element.nativeElement.querySelector('app-image-only-paragraph-type').insertAdjacentHTML('afterend', imageContent);
    // this.element.nativeElement.querySelector('app-text-only-paragraph-type').insertAdjacentHTML('afterend', textContent);

    // // this.element.nativeElement.querySelector('app-image-only-paragraph-type').remove();
    // // this.element.nativeElement.querySelector('app-text-only-paragraph-type').remove();

    // var html = removeAngularTags(this.element.nativeElement.innerHTML)

    var html=`<div class="row">
    <div class="col-12 col-md-6">
        `+imageContent+`
    </div>
    <div class="col-12 col-md-6">
        `+textContent+` 
    </div>
</div>`

    return '<div class="paragraph image-text">'+html+'</div>';
  }

  setParagraphContent(paragraphHtml:Element){
    var img=paragraphHtml.querySelector('.image-only');
    var text=paragraphHtml.querySelector('.text-only');
    this.imageOnlyParagraph.setParagraphContent(img);
    this.textOnlyParagraph.setParagraphContent(text);
  }
}
