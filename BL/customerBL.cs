using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class customerBL : ICustomerBL
    {
        ICustomerDL customerDL;
        public customerBL(ICustomerDL customerDL)
        {
            this.customerDL = customerDL;
        }

        public async Task<int> addNewCustomer(Customer customerToAdd)
        {
            return await customerDL.addNewCustomer(customerToAdd);
        }

        public async Task deleteCustomer(int id)
        {
             await customerDL.deleteCustomer(id);
        }

        public async Task<List<Customer>> getAllCustomers()
        {
            return await customerDL.getAllCustomers();
        }

        public async Task<Customer> getCustomer(int id)
        {
            return await customerDL.getCustomer(id);
        }

        public async Task  updateCustomer(Customer customerToUpdate, int id)
        {
            await customerDL.updateCustomer(customerToUpdate,id);
        }

    }
}
