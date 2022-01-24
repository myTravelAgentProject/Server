import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../models/Customer.model';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

   baseUrl: string = "/api/Customer";
  constructor(private _http: HttpClient) { }

  getAllCustomers(): Observable<Customer[]> {
    return this._http.get<Customer[]>(this.baseUrl)
  }
  getByCustomerId(id: string): Observable<Customer> {
    return this._http.get<Customer>(this.baseUrl+id)
  }
  addNewCustomer(newCustomer:Customer):Observable<any>{
      return this._http.post<any>(this.baseUrl,newCustomer)
  }
  updateCustomer(customerToUpdate:Customer):Observable<any>{
    return this._http.put(this.baseUrl+customerToUpdate.id,customerToUpdate)
    }
    deleteCustomer(id:number):Observable<any>{
    return this._http.delete(this.baseUrl+id)
    }
}