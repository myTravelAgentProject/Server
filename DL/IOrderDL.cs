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
        Task<List<Order>> getEventsForCalender(DateTime year, DateTime month);
    }
}
