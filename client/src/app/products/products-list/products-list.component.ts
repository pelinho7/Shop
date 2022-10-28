import { Component, HostListener, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { DynamicControl } from '../../_models/dynamicControl';
import { Product } from '../../_models/product';
import { ProductService } from '../../_services/product.service';
import { FormsModule, NgForm } from '@angular/forms';
import { FilterAttribute } from '../../_models/filterAttribute';
import { Pagination } from 'src/app/_models/pagination';
import { ResizeWindowWatcherService } from 'src/app/_services/resize-window-watcher.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsFilterService } from 'src/app/_services/products-filter.service';
import { CategoryService } from 'src/app/_services/category.service';
import { CategoryTreeItem } from 'src/app/_models/categoryTreeItem';
import { take } from 'rxjs/operators';
import { ProductsFilterComponent } from '../products-filter/products-filter.component';
import { ProductListItem } from 'src/app/_models/productListItem';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css', './../../shared/mobile-sidenav.css']
})
export class ProductsListComponent implements OnInit {
  products: ProductListItem[] = [];
  filterAttributes: FilterAttribute[];
  pagination: Pagination;
  paginationPanelStyles = new Map<string, string>();
  category: string = '';
  @ViewChild(ProductsFilterComponent) productsFilterRef: ProductsFilterComponent;
  @ViewChild('editForm') editForm: NgForm;


  constructor(private productService: ProductService
    , public resizeWindowWatcherService: ResizeWindowWatcherService
    , private route: Router
    , private productsFilterService: ProductsFilterService
    , private categoryService: CategoryService
    , private activatedRoute: ActivatedRoute) { }

  ii: number = 0
  ngOnInit(): void {
    this.route.routeReuseStrategy.shouldReuseRoute = () => false;
    // if(this.ii>2) return;
    // this.ii++;
    var urlParam = '';
    var urlWithoutParams = '';

    //var category = '';
    if (this.route.url.includes('?')) {
      var paramIndexStart = this.route.url.indexOf('?');
      urlParam = this.route.url.substring(paramIndexStart + 1);
      urlWithoutParams = this.route.url.substring(0, paramIndexStart);
    }
    else {
      urlWithoutParams = this.route.url;
    }

    this.category = this.getCategoryCodeFromUrl(this.route.url);// this.route.url.substring(this.route.url.lastIndexOf('/')).replace('/', '');

    this.loadProducts(this.category, (urlParam.length > 0 ? '?' + urlParam : ''));

    this.loadFilters(this.category, urlWithoutParams)
  }

  getCategoryCodeFromUrl(url: string) {
    if (url.includes('?')) {
      var paramIndexStart = this.route.url.indexOf('?');
      url = this.route.url.substring(0, paramIndexStart);
    }
    return url.substring(url.lastIndexOf('/')).replace('/', '')
  }

  openMobileFilter() {
    var nav = (document.querySelector('#filter-products-panel') as HTMLElement);
    nav.style.width = '100%';
    nav.style.transition = '0.5s'

    var topNav = (document.querySelector('#top-navbar') as HTMLElement);
    topNav.style.zIndex = '-1';
  }

  // closeNav(){
  //   (document.querySelector('#side-navbar') as HTMLElement).style.width = '0%';
  // }

  loadFilters(category: string, url: string) {
    this.productsFilterService.getFilterControls(category, url).subscribe(_ => { })
  }

  getFilterDynamicControl(filterAttributes: FilterAttribute[] = []) {
    let dynamicControls: DynamicControl[] = [];
    if (filterAttributes && filterAttributes.length > 0)
      filterAttributes.map(x => x.dynamicControls).forEach(x => dynamicControls = [...dynamicControls, ...x]);

    return dynamicControls;
  }

  loadProducts(category: string, initPath: string = '', filterAttributes: FilterAttribute[] = []) {
    let dynamicControls = this.getFilterDynamicControl(filterAttributes);

    this.productService.getProducts(category, dynamicControls, initPath, this.pagination).subscribe(results => {
      this.products = results.products;
      this.pagination = results.pagination;
      this.route.navigateByUrl('/products/' + category + results.path);
    })
  }

  filterProducts() {
    //this.loadProducts();
  }

  onFilter(event: any) {
    var filters: FilterAttribute[] = [];
    this.productsFilterService.filters$.pipe(take(1)).subscribe(x => filters = x)
    let dynamicControls = this.getFilterDynamicControl(filters);

    var paramsResult = this.productService.createProductsUrlParams(dynamicControls, this.pagination)
    var path = paramsResult[0] as string;
    this.route.navigateByUrl('/products/' + this.category + path);
    //this.loadProducts(this.category,'',filters)
  }

  pageChanged(event: any) {
    this.pagination.page = event.page;
    this.onFilter(null);
  }


}


