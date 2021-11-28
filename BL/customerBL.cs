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

        public async Task<List<Customer>> getAllCustomers()
        {
            return await customerDL.getAllCustomers();
        }
    }
}
