export class Hotel{
    id:number;
    name:string;
    ptoductUrl?:string;
    accessibility?:string;
    adress:string;
    city:string;
    email?:string;
    kosher?:string;
    parking?:string;
    phone?:string;
    region?:string;
    swimmingPool?:string;
    url?:string;
    wifi?:string;
    
    constructor( id:number, name:string,adress:string,city:string, ptoductUrl?:string,accessibility?:string,kosher?:string,parking?:string, phone?:string,
        region?:string,swimmingPool?:string,url?:string,wifi?:string) {
        this.id=id;
        this.name=name;
        this.adress=adress;
        this.city=city;
        this.ptoductUrl=ptoductUrl;
        this.accessibility=accessibility;
        this.kosher=kosher;
        this.parking=parking;
        this.phone=phone;
        this.region=region;
        this.swimmingPool=swimmingPool;
        this.url=url;
        this.wifi=wifi;
    }
}