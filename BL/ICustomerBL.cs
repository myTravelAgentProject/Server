using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ICustomerBL
    {
        //(get)
        public Task<List<Customer>> getAllCustomers();
        //(get {id})
        public Task<Customer> getCustomer(int id);
        //(post)
        public Task<int> addNewCustomer(Customer customerToAdd);
        //(put)
        public Task updateCustomer(Customer customerToUpdate, int id);
        //(delete)
        public Task deleteCustomer(int id);

    }
}
