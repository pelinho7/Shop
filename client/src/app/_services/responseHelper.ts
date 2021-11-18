import { HttpHeaders } from "@angular/common/http";

// export function getPaginationResult<T>(responseHeader:HttpHeaders) {

//     T onj = JSON.parse(responseHeader.get('Pagination'));
//     // return http.get<T>(url, { observe: 'response', params }).pipe(
//     //   map(response => {
//     //     paginatedResult.result = response.body;
//     //     if (response.headers.get('Pagination') !== null) {
//     //       paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
//     //     }
//     //     return paginatedResult;
//     //   })
//     // );
//   }