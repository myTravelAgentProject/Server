using DL;
using System;
using Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTO;

namespace BL
{
    public class orderBL : IOrderBL
    {
        IOrderDL orderDL;
        public orderBL(IOrderDL orderDL)
        {
            this.orderDL = orderDL;
        }

        public async Task<int> addNewOrder(Order newOrder)
        {
            return await orderDL.addNewOrder(newOrder);
        }

        public async Task deleteOrder(int id)
        {
           await orderDL.deleteOrder(id);
        }

        public async Task<List<Order>> getAllChanges()
        {
            return await orderDL.getAllChanges();
        }

        public async Task<List<Order>> getOrsersToCheck(DateTime today)
        {
            return await orderDL.getOrsersToCheck(today);
        }

        public async Task<List<Order>> getTheLastOrders()
        {
            return await orderDL.getTheLastOrders();
        }

        public async Task<List<OrderForCalendar>> getEventsForCalender(DateTime startDate, DateTime endDate)
        {
            return await orderDL.getEventsForCalender(startDate, endDate);
        }

        public async Task<Order> getOrderById(int id)
        {
            return await orderDL.getOrderById(id);
        }

        public async Task<List<Order>> getOrdetsBetweenDates(DateTime start, DateTime end)
        {
            return await orderDL.getOrdetsBetweenDates(start, end);
        }

        public async Task updateOrder(Order orderToUpdate, int id)
        {
            await orderDL.updateOrder(orderToUpdate,id);
        }

       
    }

}
