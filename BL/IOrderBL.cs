using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IOrderBL
    {
        public Task<List<OrderForCalendar>> getEventsForCalender(DateTime startDate, DateTime endDate);
        //public Task<Order> getOrderById(int id);
        //public Task<List<Order>> getByCustomerId(int id);
        //public Task<int> addNewOrder(Order newOrder);
        //public Task<List<Order>> getByBookingDate(DateTime bookingDate);
        //public Task<List<Order>> getAllChanges();
        //public Task<List<Order>> getOrdetsBetweenDates(DateTime start, DateTime end);
    }
}
