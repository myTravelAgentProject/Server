using AutoMapper;
using DTO;
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
        MyTravelAgent2Context myTravelAgentContext;
        IMapper mapper;
        int pageSize =20;
        public orderDL(MyTravelAgent2Context myTravelAgentContext, IMapper mapper)
        {
            this.myTravelAgentContext = myTravelAgentContext;
            this.mapper = mapper;
        }

        public async Task<int> addNewOrder(Order newOrder)
        {
            await myTravelAgentContext.Orders.AddAsync(newOrder);
           await  myTravelAgentContext.SaveChangesAsync();
            return newOrder.Id;
        }

        public async Task deleteOrder(int id)
        {
            Order ordertoDelete =await myTravelAgentContext.Orders.FindAsync(id);
            myTravelAgentContext.Orders.Remove(ordertoDelete);
            await myTravelAgentContext.SaveChangesAsync();

        }

        public async Task<List<Order>> getAllChanges()
        {
            return await myTravelAgentContext.Orders.Where(o => o.Change == true)
                .Include(c => c.Customer)
                .Include(h => h.Hotel).ToListAsync();
        }

        public async Task<List<Order>> getOrsersToCheck(DateTime today)
        {
            return await myTravelAgentContext.Orders.Where(o => o.IsImportant == true || (o.CheckInDate > today && o.CheckInDate < (today.AddMonths(2))))
                .Include(c => c.Customer)
                .Include(h => h.Hotel).ToListAsync();
        }

        public async Task<List<Order>> getTheLastOrders()
        {
            return await myTravelAgentContext.Orders
                        .OrderByDescending(o => o.BookingDate)
                        .Include(c => c.Customer)
                        .Include(h => h.Hotel).ToListAsync();
        }

        public async Task<List<Order>> getByCustomerId(int id)
        {
            return await myTravelAgentContext.Orders.Where(o => o.CustomerId == id).Include(c => c.Customer)
                .Include(h => h.Hotel).ToListAsync();
        }

        public async Task<List<Order>> getEventsForCalender(DateTime startDate, DateTime endDate)
        {
            return await myTravelAgentContext.Orders.Where(o => o.CheckInDate >= startDate && o.CheckInDate <= endDate||o.CheckOutDate >= startDate &&o.CheckOutDate <=endDate)
                .Include(c=>c.Customer)
                .Include(h=>h.Hotel)
                .ToListAsync();



            //ordersToShow = (
            //                       join c in myTravelAgentDBContext.Customers on o.CustomerId equals c.Id
            //                       where 
            //                       select new OrderForCalendar {
            //                           orderId = o.Id,
            //                           customerName=o.Customer.FirstName +" "+ o.Customer.LastName,
            //                           hotelName = o.Hotel.Name,
            //                            checkInDate=o.CheckInDate,
            //                            checkOutDate=o.CheckOutDate,
            //                            earlyCheckIn=o.EarlyCheckIn,
            //                            lateCheckOut=o.LateCheckOut
            //                       }).ToList();


            //return  ordersToShow;
        }

        public async Task<Order> getOrderById(int id)
        {
            return await myTravelAgentContext.Orders.Include(c => c.Customer).Include(h => h.Hotel).Where(o => o.Id == id)
                .FirstOrDefaultAsync();
        }

        //public async Task<List<Order>> getOrdetsBetweenDates(DateTime start, DateTime end)
        //{
        //    return await myTravelAgentContext.Orders.Where(o => o.CheckInDate > start && o.CheckInDate < end)
        //        .Include(c => c.Customer)
        //        .Include(h => h.Hotel).ToListAsync();
        //}

        public async Task updateOrder(Order orderToUpdate, int id)
        {
            Order order = await myTravelAgentContext.Orders.FindAsync(id);
            myTravelAgentContext.Entry(order).CurrentValues.SetValues(orderToUpdate);
            await myTravelAgentContext.SaveChangesAsync();
        }

        public async Task<List<Order>> getOrdersByQeryParams(string hotelName, string customerName, int page)
        {
            return await myTravelAgentContext.Orders
               .Where(o=>o.Hotel.Name.Contains(hotelName) && (o.Customer.FirstName+" "+o.Customer.LastName).Contains(customerName))
               .OrderByDescending(o => o.CheckOutDate).Skip(pageSize * page).Take(pageSize)
               .Include(c => c.Customer)
               .Include(h => h.Hotel).ToListAsync();
        }

        public async Task<List<Order>> getOrdersBetweenDates(string hotelName, string customerName, DateTime start, DateTime end, int page)
        {
            return await myTravelAgentContext.Orders
                .Where(o => o.Hotel.Name.Contains(hotelName)
               && (o.Customer.FirstName + " " + o.Customer.LastName).Contains(customerName)
               && ((o.CheckInDate <= end && o.CheckOutDate >= start)))
               .OrderByDescending(o => o.CheckOutDate).Skip(pageSize * page).Take(pageSize)
               .Include(c => c.Customer)
               .Include(h => h.Hotel)
               .ToListAsync();
        }
    }
}
