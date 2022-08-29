import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ComponentFactoryResolver, ComponentRef, ElementRef, HostListener, OnInit, ViewChild, ViewContainerRef, ViewRef } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';

@Component({
  selector: 'app-text-only-paragraph-type',
  templateUrl: './text-only-paragraph-type.component.html',
  styleUrls: ['./text-only-paragraph-type.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TextOnlyParagraphTypeComponent implements OnInit {
  public html:string=''
  editorConfig: AngularEditorConfig = {
    editable: true,
      spellcheck: true,
      height: 'auto',
      minHeight: '0',
      maxHeight: 'auto',
      width: 'auto',
      minWidth: '0',
      translate: 'yes',
      enableToolbar: true,
      showToolbar: true,
      placeholder: 'Enter text here...',
      defaultParagraphSeparator: '',
      defaultFontName: '',
      defaultFontSize: '',
      fonts: [
        {class: 'arial', name: 'Arial'},
        {class: 'times-new-roman', name: 'Times New Roman'},
        {class: 'calibri', name: 'Calibri'},
        {class: 'comic-sans-ms', name: 'Comic Sans MS'}
      ],
    toolbarPosition: 'top',
    toolbarHiddenButtons: [
      [
        'insertImage',
        'toggleEditorMode',
        'clearFormatting',
        'insertHorizontalRule',
        'insertVideo',
        'backgroundColorPicker',
        'link',
        'unlink',
        'underline',
        'strikeThrough',
        'subscript',
        'superscript',
        'justifyLeft',
        'justifyCenter',
        'justifyRight',
        'justifyFull',
        'indent',
        'outdent',
        'fontName'
      ],
      [
        'fontSize',
        'textColor',
        'backgroundColor',
        'customClasses',
        'link',
        'unlink',
        'insertImage',
        'insertVideo',
        'insertHorizontalRule',
        'removeFormat',
        'toggleEditorMode'
      ]
    ]
};

editMode:boolean=true;
manualCreated:boolean=false;
@HostListener('document:click', ['$event'])
  clickout(event:any) {
    if(this.manualCreated){
      this.manualCreated=false;
      return;
    }
    if(this.eRef.nativeElement.contains(event.target)) {
      this.editMode=true;
    } else {
      this.editMode=false;
    }
    if(this.html == null || this.html.length==0){
      this.editMode=true;
    }
  }
 
  constructor(private eRef: ElementRef) { }

  ngOnInit(): void {

  }
  ngAfterViewInit(){

  }

  getParagraphContent(mainElement:boolean=true){
    if(this.html.length==0){
      throw new Error('Please set text in description paragraph or remove it.')
    }
    var containter='';
    if(mainElement){
      containter='<div class="paragraph text-only">'
    }
    else{
      containter='<div class="text-only">'
    }
    return containter+this.html+'</div>';
  }

  setParagraphContent(paragraphHtml:Element){
    this.html = paragraphHtml.innerHTML;
  }
}
