export class CustomerChildren{
    id:number;
    customerId:number;
    name?:string;
    age:number;
    
    constructor( id:number,  customerId:number,age:number, name?:string) {
      this.id=id;
      this.customerId=customerId;
      this.age=age;
      this.name=name;
      

    }
}