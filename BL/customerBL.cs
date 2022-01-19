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
        public customerBL(ICustomerDL customerDL)
        {
            this.customerDL = customerDL;
        }

        //(get)
        public async Task<List<customerDTO>> getAllCustomers()
        {
            return await customerDL.getAllCustomers();
        }

        //(get {id})
        public async Task<customerDTO> getCustomer(int id)
        {
            return await customerDL.getCustomer(id);
        }
        //(get {id})
        //public Task<List<Order>> getAllCustomerOrders(int id)
        //{
        //    return await customerDL.getAllCustomerOrders(id);
        //}

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
