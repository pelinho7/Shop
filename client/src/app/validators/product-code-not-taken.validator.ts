import { AbstractControl } from '@angular/forms';
import { map } from 'rxjs/operators';
import { ProductService } from '../_services/product.service';

export class ProductCodeNotTaken {
  static createValidator(productService: ProductService) {
    return (control: AbstractControl) => {
      return productService.checkCodeNotTaken(control.value).pipe(
          map(res => {
        return res ? null : {categoryCodeTaken: true};
      }))
    }
  }
}