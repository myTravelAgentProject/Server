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
        MyTravelAgentDBContext myTravelAgentDBContext;
        public customerDL(MyTravelAgentDBContext myTravelAgentDBContext)
        {
            this.myTravelAgentDBContext = myTravelAgentDBContext;
        }

        public async Task<List<Customer>> getAllCustomers()
        {
            return null;
        }
    }
}
