using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrderDL
    {
           public Task<List<OrderForCalendar>> getEventsForCalender(DateTime startDate, DateTime endDate);
       
    }
}
