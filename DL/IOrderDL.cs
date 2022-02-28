using DTO;
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
        public Task<List<OrderDTO>> getEventsForCalender(DateTime startDate, DateTime endDate);
        public Task<OrderDTO> getOrderById(int id);
        public Task<List<OrderDTO>> getByCustomerId(int id);
        public Task<int> addNewOrder(Order newOrder);
        public Task<List<OrderDTO>> getTheLastOrders();
        public Task<List<OrderDTO>> getAllChanges();
        public Task<List<OrderDTO>> getOrdetsBetweenDates(DateTime start, DateTime end);
        public Task deleteOrder(int id);
        public Task<List<OrderDTO>> getOrsersToCheck(DateTime today);
        public Task updateOrder(Order orderToUpdate, int id);
    }
}
