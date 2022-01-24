import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './admin/admin.component';
import { MatSliderModule } from '@angular/material/slider';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
//import { CustomerComponent } from './modules/customer/customer.component';
import {MatInputModule} from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { CustomerModule } from './modules/cutomer.module';
//import { UpdateCustomerComponent } from './modules/update-customer/update-customer.component';


@NgModule({
  declarations: [
    AppComponent,
    AdminComponent


  ],
  imports: [
    BrowserModule,
    MatSliderModule,
    AppRoutingModule,
     ReactiveFormsModule,
     FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CustomerModule,

    ///////////////// material modules /////////////////
    MatInputModule,
    MatButtonModule,
    MatIconModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
