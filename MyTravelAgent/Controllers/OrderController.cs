using BL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTravelAgent.Controllers
{ 
    
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;       
        }

        //return all the orders that their price had change (the 'change' filed is true)
        [HttpGet ("ChangedPriceOrders")]
        public async Task<List<Order>> GetChangePriceOrders()
        {
            return await orderBL.getAllChanges();
        }

        // return a order according to its id
        [HttpGet("{id}")]
        public async Task<Order> getOrderById(int id)
        {
            return await orderBL.getOrderById(id);
        }


        /*return a list of 15 last taching orders*/
        [HttpGet ("lastOrders")]
        public async Task<List<Order>> getTheLastOrders()
        {
            return await orderBL.getTheLastOrders();
        }

        //get orders between two dates
        [HttpGet("betweenDates/{start}/{end}")]
        public async Task<List<Order>> Get(DateTime start, DateTime end)
        {
            return await orderBL.getOrdetsBetweenDates(start, end);
        }

        //add a order
        [HttpPost]
        public async Task<int> Post([FromBody] Order newOrder)
        {
            return await orderBL.addNewOrder(newOrder);
        }

        //update a order according to the given id
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Order orderToUpdate)
        {
            await orderBL.updateOrder(orderToUpdate,id);
        }

        //delete a order according to the id
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await orderBL.deleteOrder(id);
        }
    }
}
