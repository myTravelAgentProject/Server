using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class customerDL: ICustomerDL
    {
        MyTravelAgentContext myTravelAgentContext;
        public customerDL(MyTravelAgentContext myTravelAgentContext)
        {
            this.myTravelAgentContext = myTravelAgentContext;
        }

        //(get) returns a list of all the customers
        public async Task<List<Customer>> getAllCustomers()
        { 
            return myTravelAgentContext.Customers.ToList();
        }

        //(get {id}) returns a customer according to the id
        public async Task<Customer> getCustomer(int id)
        {
            return await myTravelAgentContext.Customers.FindAsync(id);
        }

        /*(post) adds the new customer to the table,
         save the changes
        returns the id of the new customer from the db*/
        public async Task<int> addNewCustomer(Customer customerToAdd)
        {
            await myTravelAgentContext.Customers.AddAsync(customerToAdd);
            myTravelAgentContext.SaveChanges();
            return customerToAdd.Id;
        }

        /*(put) finds the customer we want to change (according to the id),
         replace the customer with the new cuatomer (with the changes)
        save the changes*/
        public async Task updateCustomer(Customer customerToUpdate, int id)
        {
            Customer customer = await myTravelAgentContext.Customers.FindAsync(id);
            myTravelAgentContext.Entry(customer).CurrentValues.SetValues(customerToUpdate);
            await myTravelAgentContext.SaveChangesAsync();
        }

        /*(delete) finds the customer according to the id,
         remove the customrt that found,
        save the changes*/
        public async Task deleteCustomer(int id)
        {
            Customer toDelete = await myTravelAgentContext.Customers.FindAsync(id);
            myTravelAgentContext.Customers.Remove(toDelete);
            await myTravelAgentContext.SaveChangesAsync();
        }
    }
}
