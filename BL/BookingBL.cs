using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BookingBL:IBookingBL
    {
        IOrderBL orderBL;
        public BookingBL(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }
        public async Task<List<Order>> updateOrders()
        {
            return await orderBL.getOrsersToCheck(DateTime.Now);
        }
    }
}
