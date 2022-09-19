export class Discount {
    id:number=0
    type:number=0
    deleted:boolean=false
    value :number=0;
    productId :number;
    categoryId :number;
    startDate:Date = new Date();
    endDate :Date = new Date();
    startDateString:string = '';
    endDateString:string = '';

    constructor(){}
}