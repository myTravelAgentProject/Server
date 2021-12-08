using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface ICustomerDL
    {
        public Task<List<Customer>> getAllCustomers();
        public Task<Customer> getCustomer(int id);
        public Task updateCustomer(Customer customerToUpdate, int id);
        public Task<int> addNewCustomer(Customer customerToAdd);
        public Task deleteCustomer(int id);
    }
}
