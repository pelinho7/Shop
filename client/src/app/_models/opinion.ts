export class Opinion {
    id: number=0;
    rating: number;
    title: string='';
    content: string='';
    productId: number=0;
    deleted: boolean=false;
    userName: string='';
    userId: number=0;
    createDate: Date;
    modDate:Date;
    
    constructor(){}
}