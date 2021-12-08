using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task updateOrders()
        {
            ordersToCheck=await orderBL.getOrsersToCheck(DateTime.Now);
            foreach(Order order in ordersToCheck)
            {
                //check if order had change in booking and save the new price into newPrice
                //update the order:
                if (order.TotalPrice > newPrice)
                {
                    order.NewPrice = newPrice;
                    order.Change = true;
                    await orderBL.updateOrder(order, order.Id);
                }
            }
        }
    }
}
