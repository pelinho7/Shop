import { Agreement } from "./agreement";

export class Registration {
    email :string="";
    firstName :string="";
    lastName :string="";
    password :string="";
    passwordRepeated :string="";
    agreements:Agreement[];

    constructor(){}
}