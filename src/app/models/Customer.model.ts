export class Customer{
    id:number;
    firstName:string;
    lastName:string;
    numOfAdults?:number;
    numOfKIds?:number;
    highFloor?:boolean;
    porch?:boolean;
    separteBeds?:boolean;
    multipleRooms?:boolean;
    emailAdress?:string;
    address:string;
    phoneNumber:string;
    comments?:string;

    
    constructor( id:number,  firstName:string,lastName:string, address:string,phoneNumber:string,numOfAdults?:number,numOfKIds?:number,
          highFloor?:boolean,porch?:boolean,separteBeds?:boolean,multipleRooms?:boolean,emailAdress?:string, comments?:string)
   {
      this.id=id;
      this.firstName=firstName;
      this.lastName=lastName;
      this.address=address;
      this.phoneNumber=phoneNumber;
      this.numOfAdults=numOfAdults;
      this.numOfKIds=numOfKIds;
      this.highFloor=highFloor;
      this.porch=porch;
      this.separteBeds=separteBeds;
      this.multipleRooms=multipleRooms;
      this.emailAdress=emailAdress;
      this.comments=comments;
   }
}