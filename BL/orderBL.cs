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

        Task<List<Order>> getEventsForCalendar(DateTime startDate, DateTime endDate)
        {
            return orderDL.getEventsForCalendar(startDate, endDate);
        }
    }
}
