using DL;
using System;
using Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BL
{
    public class orderBL : IOrderBL
    {
        IOrderDL orderDL;
        public orderBL(IOrderDL orderDL)
        {
            this.orderDL = orderDL;
        }

     public async  Task<List<Order>> getEventsForCalender(DateTime startDate, DateTime endDate)
        {
            return await orderDL.getEventsForCalender(startDate, endDate);
        }
    }


}
