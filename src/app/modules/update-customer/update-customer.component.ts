import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';

@Component({
  selector: 'app-update-customer',
  templateUrl: './update-customer.component.html',
  styleUrls: ['./update-customer.component.css']
})
export class UpdateCustomerComponent implements OnInit {

  
  constructor() { }

    customerForm:FormGroup=new FormGroup({
      "FirstName":new FormControl("",Validators.required),
      "LastName":new FormControl("",Validators.required),
      "NumOfAdults":new FormControl(""),
      "NumOfKids":new FormControl(""),
      "HighFloor":new FormControl(""),
      "Porch":new FormControl(""),
      "SeparteBeds":new FormControl(""),
      "MultipleRooms":new FormControl(""),
      "EmailAdress":new FormControl("",Validators.email),
      "Address":new FormControl("",Validators.required),
      "PhoneNumber":new FormControl("",Validators.required),
      "Comments":new FormControl(""),
    });
  ngOnInit(): void {
 
  }

}
