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
        public async Task<List<Customer>> getAllCustomers()
        { 
            return myTravelAgentContext.Customers.ToList();
        }

        public async Task<Customer> getCustomer(int id)
        {
            return await myTravelAgentContext.Customers.FindAsync(id);
        }

        public async Task updateCustomer(Customer customerToUpdate, int id)
        {
            Customer customer = await myTravelAgentContext.Customers.FindAsync(id);
            myTravelAgentContext.Entry(customer).CurrentValues.SetValues(customerToUpdate);
            await myTravelAgentContext.SaveChangesAsync();
        }
        public async Task<int> addNewCustomer(Customer customerToAdd)
        { 
            myTravelAgentContext.Customers.AddAsync(customerToAdd);
            myTravelAgentContext.SaveChanges();
            return customerToAdd.Id;
        }

        public async Task deleteCustomer(int id)
        {
            Customer toDelete = await myTravelAgentContext.Customers.FindAsync(id);
            myTravelAgentContext.Customers.Remove(toDelete);
            await myTravelAgentContext.SaveChangesAsync();
        }
    }
}
