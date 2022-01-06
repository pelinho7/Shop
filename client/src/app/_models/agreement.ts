export class Agreement {
    id :number;
    type:number;
    contents :string;
    obligatory :boolean;
    checked:boolean=false;
    removable:boolean=false;
    modDate:Date;

    constructor(){}
}