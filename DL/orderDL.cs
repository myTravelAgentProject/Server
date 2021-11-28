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

        public async Task<List<OrderForCalendar>> getEventsForCalender(DateTime startDate, DateTime endDate)
        {
            List<OrderForCalendar> ordersToShow = new List<OrderForCalendar>();
            var orderListToShow = await myTravelAgentContext.Orders.Join(myTravelAgentContext.Customers, order => order.CustomerId, customer => customer.Id, (order, customer) => new {
                order.Id,customer.FirstName,customer.LastName,order.HotelId,order.CheckInDate,
                order.CheckOutDate,order.EarlyCheckIn,order.LateCheckOut })
                .Join(myTravelAgentContext.Hotels, newOrder => newOrder.HotelId, hotel => hotel.Id, (newOrder, hotel) => new {
                newOrder.Id,newOrder.FirstName,newOrder.LastName,hotel.Name,newOrder.CheckInDate,newOrder.CheckOutDate,newOrder.EarlyCheckIn,newOrder.LateCheckOut})
                            .Where(order => order.CheckInDate >= startDate && order.CheckInDate <= endDate)
                            .ToListAsync();

            var orderListToShow1 = (from o in myTravelAgentContext.Orders
                                    join c in myTravelAgentContext.Customers on o.CustomerId equals c.Id
                                    //  join h in myTravelAgentContext.Hotels on o.HotelId equals h.Id
                                    where o.CheckInDate >= startDate && o.CheckInDate <= endDate
                                    select new OrderForCalendar {
                                        //hotelName=h.Name
                                        hotelName = o.Hotel.Name
                                    }).ToList();

            orderListToShow.ForEach(order =>
            {
                OrderForCalendar ofc = new OrderForCalendar {
                
                orderId = order.Id,
                customerName = order.FirstName + " " + order.LastName,
                hotelName = order.Name,
                checkInDate = order.CheckInDate,
                checkOutDate = order.CheckOutDate,
                earlyCheckIn = order.EarlyCheckIn,
                lateCheckOut = order.LateCheckOut
            };
                ordersToShow.Add(ofc);
            });
            return  ordersToShow;
            //return await myTravelAgentContext.Orders
            //    .Where(order => order.CheckInDate >= startDate && order.CheckInDate <= endDate).ToListAsync();
        }
    }
}
