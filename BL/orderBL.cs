using DL;
using System;
using Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTO;
using System.Globalization;
using PagedList;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Linq;

namespace BL
{
    public class orderBL : IOrderBL
    {
        IOrderDL orderDL;
        IMapper mapper;
        public orderBL(IOrderDL orderDL, IMapper imapper)
        {
            this.orderDL = orderDL;
            mapper = imapper;
        }

        public async Task<int> addNewOrder(Order newOrder)
        {
            newOrder.Comments = newOrder.Comments.Trim();
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

        public async Task<OrderDataList> getTheLastOrders(int page, int pageSize)
        {
            OrderDataList orderData = new OrderDataList();
            List<Order> data = await orderDL.getTheLastOrders();
            orderData.TotalRows = data.Count;
            List<Order> dataFiltered = data.Skip(pageSize * page).Take(pageSize).ToList();
            orderData.Orders = mapper.Map<List<Order>, List<OrderDTO>>(dataFiltered);
            return orderData;
        }

        public async Task<List<Order>> getEventsForCalender(DateTime startDate, DateTime endDate)
        {
            return await orderDL.getEventsForCalender(startDate, endDate);
        }

        public async Task<Order> getOrderById(int id)
        {
            return await orderDL.getOrderById(id);
        }

        //public async Task<List<Order>> getOrdetsBetweenDates(DateTime start, DateTime end)
        //{
        //    return await orderDL.getOrdetsBetweenDates(start, end);
        //}

        public async Task updateOrder(Order orderToUpdate, int id)
        {
            orderToUpdate.Comments = orderToUpdate.Comments.Trim();
            await orderDL.updateOrder(orderToUpdate,id);
        }

        public async Task<OrderDataList> getOrdersByQeryParams(string customerName, string hotelName, string startDate, string endDate, int page, int pageSize)
        {
            OrderDataList orderData = new OrderDataList();
            if (customerName == null)
                customerName = "";
            if (hotelName == null)
                hotelName = "";
            if (startDate != null)
            {
                DateTime start = DateTime.Parse(startDate);
                DateTime end = DateTime.Parse(endDate);
                //DateTime start = DateTime.ParseExact(startDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                //DateTime end = DateTime.ParseExact(endDate,"dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                List<Order> data = await orderDL.getOrdersBetweenDates(hotelName, customerName, start, end); 
                orderData.TotalRows = data.Count;
                List<Order> dataFiltered = data.Skip(pageSize * page).Take(pageSize).ToList();
                orderData.Orders = mapper.Map<List<Order>, List<OrderDTO>>(dataFiltered);

            }
            else
            {
                List<Order> data = await orderDL.getOrdersByQeryParams(hotelName, customerName);
                orderData.TotalRows = data.Count;
                List<Order> dataFiltered = data.Skip(pageSize * page).Take(pageSize).ToList();
                orderData.Orders = mapper.Map<List<Order>, List<OrderDTO>>(dataFiltered);
            }
            return orderData;
        }
    }

 

}
