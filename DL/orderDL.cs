using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
    public class orderDL : IOrderDL
    {
        MyTravelAgentContext myTravelAgentContext;
        public orderDL(MyTravelAgentContext myTravelAgentContext)
        {
            this.myTravelAgentContext = myTravelAgentContext;
        }

        public async Task<List<Order>> getEventsForCalender(DateTime startDate, DateTime endDate)
        { 
            return await myTravelAgentContext.Orders
                .Where(order => order.CheckInDate >= startDate && order.CheckInDate <= endDate).ToListAsync();
        }
    }
}
