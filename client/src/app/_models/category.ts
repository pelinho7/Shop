import { CategoryAttribute } from "./categoryAttribute"

export class Category {
    id:number=0
    code:string=''
    label:string=''
    deleted:boolean=false
    categoryAttributes:CategoryAttribute[]=[]
    parentCategoriesAttributes:CategoryAttribute[]=[]
   
    constructor(){}
}