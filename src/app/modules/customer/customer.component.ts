import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/Customer.model';
import { CustomerService } from 'src/app/services/customer.service';
//import { threadId } from 'worker_threads';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(private _customerService:CustomerService) { }

  customer!:Customer[];
 getAllCustomers(){
   this._customerService.getAllCustomers().subscribe(data=>
  {if(data) {this.customer=data;console.log(this.customer)} else{console.log("no such user")}})
  }

  ngOnInit(): void {
  }

}
