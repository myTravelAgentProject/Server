import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { CustomerService } from "../services/customer.service";
import { CustomerComponent } from "./customer/customer.component";
import { UpdateCustomerComponent } from './update-customer/update-customer.component';

@NgModule({
    declarations:[CustomerComponent, UpdateCustomerComponent],
    imports:[ReactiveFormsModule,RouterModule,FormsModule],
    providers:[CustomerService],
    exports:[CustomerComponent,UpdateCustomerComponent]
})
export class CustomerModule{
    
}