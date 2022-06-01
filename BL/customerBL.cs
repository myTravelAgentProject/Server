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
        public async Task<List<Customer>> getAllCustomers()
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
        public async Task<int> addNewCustomer(Customer customerToAdd)
        {
            customerToAdd.FirstName = customerToAdd.FirstName.Trim();
            customerToAdd.LastName = customerToAdd.LastName.Trim();
         /*   customerToAdd.EmailAddress = customerToAdd.EmailAddress.Trim();
            customerToAdd.Address = customerToAdd.Address.Trim();
            customerToAdd.Comments = customerToAdd.Comments.Trim();*/
            return await customerDL.addNewCustomer(customerToAdd);
        }

        //(put)
        public async Task updateCustomer(Customer customerToUpdate, int id)
        {
            customerToUpdate.FirstName = customerToUpdate.FirstName.Trim();
            customerToUpdate.LastName = customerToUpdate.LastName.Trim();
            //customerToUpdate.EmailAddress = customerToUpdate.EmailAddress.Trim();
            //customerToUpdate.Address = customerToUpdate.Address.Trim();
            //customerToUpdate.Comments = customerToUpdate.Comments.Trim();
            await customerDL.updateCustomer(customerToUpdate, id);
        }

        //(delete)
        public async Task deleteCustomer(int id)
        {
             await customerDL.deleteCustomer(id);
        }

        
    }
}
