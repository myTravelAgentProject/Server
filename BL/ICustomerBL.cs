using DTO;
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
        public Task<List<customerDTO>> getAllCustomers();
        //(get {id})
        public Task<Customer> getCustomer(int id);
        public Task<List<Order>> getAllCustomerOrders(int id);
        //(post)
        public Task<int> addNewCustomer(customerDTO customerToAdd);
        //(put)
        public Task updateCustomer(customerDTO customerToUpdate, int id);
        //(delete)
        public Task deleteCustomer(int id);

    }
}
