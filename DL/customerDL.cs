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

        public async void updateCustomer(Customer customerToUpdate, int id)
        {
            Customer customer = myTravelAgentContext.Customers.Find(id);
            if (customer == null)
            {
                throw new Exception("no customer with id " + customerToUpdate.Id);
            }
            myTravelAgentContext.Entry(customer).CurrentValues.SetValues(customerToUpdate);
            await myTravelAgentContext.SaveChangesAsync();
        }
        public async Task<int> addNewCustomer(Customer customerToAdd)
        { 
            myTravelAgentContext.Customers.AddAsync(customerToAdd);
            myTravelAgentContext.SaveChanges();
            return customerToAdd.Id;
        }

        public void deleteCustomer(int id)
        {
            Customer toDelete = myTravelAgentContext.Customers.Find(id);
            myTravelAgentContext.Customers.Remove(toDelete);
            myTravelAgentContext.SaveChanges();
        }
    }
}
