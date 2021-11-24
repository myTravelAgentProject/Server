using Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public class orderDL : IOrderDL
    {
        public async Task<List<Order>> getEventsForCalender(DateTime startDate, DateTime endDate)
        {
            List<Order> eventsForCalender = new List<Order>();
           
            return eventsForCalender;
        }
    }
}
