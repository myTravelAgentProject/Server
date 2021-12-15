﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BookingBL:IBookingBL
    {
        IOrderBL orderBL;
        List<Order> ordersToCheck;
        int newPrice;
        public BookingBL(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        /*(updateOrders) first gets from orderBL all the alerts within two monthes and the importence alerts
        then, run on the list and for each order:
            gets from booking.com the up to date price,
            compare the price with the old price (booking price while booked)
            and if the new price is cheeper,
        through orderBL - saves in the orders table the new price and update the feild 'change' of the order*/
        public async Task<string> updateOrders()
            
        {
            float newPrice = 0;
            ordersToCheck = await orderBL.getOrsersToCheck(DateTime.Now);
            foreach (Order order in ordersToCheck)
            {
                //string url= "https://booking-com.p.rapidapi.com/v1/hotels/search-filters?"
                //check if order had change in booking and save the new price into newPrice
               var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search-filters?units=metric&filter_by_currency=USD&locale=is&order_by=price&checkin_date=2021-12-29&checkout_date=2022-01-10&dest_type=hotel&dest_id=5052&adults_number=2&room_number=1&children_number=2&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                    Headers =
    {
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
        { "x-rapidapi-key", "16945ab38dmsh7cf2c60b016f2fep18d5c7jsna1ddd961ba77" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return body;
                }
                //update the order:
                //if (order.TotalPrice > newPrice)
                //{
                //    order.NewPrice = newPrice;
                //    order.Change = true;
                //    await orderBL.updateOrder(order, order.Id);
                //}
            }
            return null;
        }
        
    }
}
