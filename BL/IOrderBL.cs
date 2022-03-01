using DTO;
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
        public Task<List<Order>> getEventsForCalender(DateTime startDate, DateTime endDate);
        public Task<Order> getOrderById(int id);
        public Task<int> addNewOrder(Order newOrder);
        public Task<List<Order>> getTheLastOrders();
         public Task<List<Order>> getAllChanges();
        public Task<List<Order>> getOrdetsBetweenDates(DateTime start, DateTime end);
        public Task deleteOrder(int id);
        public Task updateOrder(Order orderToUpdate, int id);
        public Task<List<Order>> getOrsersToCheck(DateTime today);
    }
}
