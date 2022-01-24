export class Request{
    id:number;
    customerId:number;
    price?:number;
    area?:string;
    arriveDate?:Date;
    leavingDate?:Date;
   
    constructor(id:number,customerId:number,price?:number,area?:string,arriveDate?:Date,leavingDate?:Date) {
      this.id=id;
      this.customerId=customerId;
      this.price=price;
      this.area=area;
      this.arriveDate=arriveDate;
      this.leavingDate=leavingDate;
    }

}