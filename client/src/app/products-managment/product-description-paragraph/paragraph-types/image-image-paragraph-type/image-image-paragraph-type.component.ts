import { ChangeDetectionStrategy, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { removeAngularTags } from 'src/app/_helpers/descriptionParagraphHelpers';
import { ImageOnlyParagraphTypeComponent } from '../image-only-paragraph-type/image-only-paragraph-type.component';

@Component({
  selector: 'app-image-image-paragraph-type',
  templateUrl: './image-image-paragraph-type.component.html',
  styleUrls: ['./image-image-paragraph-type.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ImageImageParagraphTypeComponent implements OnInit {
  @ViewChild('imageOnlyParagraph1') imageOnlyParagraph1:ImageOnlyParagraphTypeComponent;
  @ViewChild('imageOnlyParagraph2') imageOnlyParagraph2:ImageOnlyParagraphTypeComponent;

  constructor(private element: ElementRef) { }

  ngOnInit(): void {
  }
  
  getParagraphContent(){
    var image1Content = this.imageOnlyParagraph1.getParagraphContent(false);
    var image2Content = this.imageOnlyParagraph2.getParagraphContent(false);
    var imageOnlyParagraphsArray = this.element.nativeElement.querySelectorAll('app-image-only-paragraph-type');
    imageOnlyParagraphsArray[0].insertAdjacentHTML('afterend', image1Content);
    imageOnlyParagraphsArray[1].insertAdjacentHTML('afterend', image2Content);
    imageOnlyParagraphsArray[0].remove();
    imageOnlyParagraphsArray[1].remove();

    var html = removeAngularTags(this.element.nativeElement.innerHTML)

    return '<div class="paragraph image-image">'+html+'</div>';
  }

  setParagraphContent(paragraphHtml:Element){
    var imgs=paragraphHtml.querySelectorAll('.image-only');
    this.imageOnlyParagraph1.setParagraphContent(imgs[0]);
    this.imageOnlyParagraph2.setParagraphContent(imgs[1]);
  }
}
