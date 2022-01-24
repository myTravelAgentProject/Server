import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Admin } from '../models/Admin.model';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  baseURL = "/api/Admin/";

  constructor(private _http: HttpClient) { }

  getAdmin(name: string, password: string): Observable<Admin> {
    return this._http.get<Admin>(`${this.baseURL + name}/${password}`)
  }
  addNewAdmin(newAdmin:Admin):Observable<any>{
    return this._http.post<any>(this.baseURL,newAdmin)
}
changePaswword(changePaswword:Admin):Observable<any>{
  return this._http.put(this.baseURL+changePaswword.id,changePaswword)
  }
}
