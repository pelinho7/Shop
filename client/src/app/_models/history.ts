import { PropertyHistory } from "./propertyHistory";

export class History{
    objectId:number;
    type:number;
    moddate:Date;
    moddateString:string;
    modtimeString:string;
    propertiesHistory:PropertyHistory[];

    constructor(){}
}