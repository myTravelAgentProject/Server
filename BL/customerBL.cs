using DL;
using DTO;
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
        IOrderDL orderDL;
        public customerBL(ICustomerDL customerDL,IOrderDL orderDL)
        {
            this.customerDL = customerDL;
            this.orderDL = orderDL;
        }

        //(get)
        public async Task<List<customerDTO>> getAllCustomers()
        {
            return await customerDL.getAllCustomers();
        }

        //(get {id})
        public async Task<Customer> getCustomer(int id)
        {
            return await customerDL.getCustomer(id);
        }
        //(get {id})
        public async Task<List<Order>> getAllCustomerOrders(int id)
        {
            return await orderDL.getByCustomerId(id);
        }

        //(post)
        public async Task<int> addNewCustomer(customerDTO customerToAdd)
        {
            return await customerDL.addNewCustomer(customerToAdd);
        }

        //(put)
        public async Task updateCustomer(customerDTO customerToUpdate, int id)
        {
            await customerDL.updateCustomer(customerToUpdate, id);
        }

        //(delete)
        public async Task deleteCustomer(int id)
        {
             await customerDL.deleteCustomer(id);
        }

        
    }
}
