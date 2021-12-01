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

        //public async Task<int> addNewOrder(Order newOrder)
        //{
        //    return await orderDL.addNewOrder(newOrder);
        //}

        //public async Task<List<Order>> getAllChanges()
        //{
        //    return await orderDL.getAllChanges();
        //}

        //public async Task<List<Order>> getByBookingDate(DateTime bookingDate)
        //{
        //    return await orderDL.getByBookingDate(bookingDate);
        //}

        //public async Task<List<Order>> getByCustomerId(int id)
        //{
        //    return await orderDL.getByCustomerId(id);
        //}

        public async Task<List<OrderForCalendar>> getEventsForCalender(DateTime startDate, DateTime endDate)
        {
            return await orderDL.getEventsForCalender(startDate, endDate);
        }

        //public async Task<Order> getOrderById(int id)
        //{
        //    return await orderDL.getOrderById(id);
        //}

        //public async Task<List<Order>> getOrdetsBetweenDates(DateTime start, DateTime end)
        //{
        //    return await orderDL.getOrdetsBetweenDates(start, end);
        //}
    }

}
