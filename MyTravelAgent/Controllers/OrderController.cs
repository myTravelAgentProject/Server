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
        //// get all the orders that their price had change
        [HttpGet]
        public async Task<List<Order>> Get()
        {
            return await orderBL.getAllChanges();
        }

        // GET api/<OrderController>/5
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<Order> getOrderById(int id)
        {
            return await orderBL.getOrderById(id);
        }

        //get by customerId
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<List<Order>> getByCustomerId(int id)
        {
            return await orderBL.getByCustomerId(id);
        }

        //get by bookingDate
        [HttpGet("{bookingDate}")]
        public async Task<List<Order>> Get(DateTime bookingDate)
        {
            return await orderBL.getByBookingDate(bookingDate);
        }

        ////get between two dates
        [HttpGet("{start}/{end}")]
        public async Task<List<Order>> Get(DateTime start, DateTime end)
        {
            return await orderBL.getOrdetsBetweenDates(start, end);
        }

        //// POST api/<OrderController>
        [HttpPost]
        public async Task<int> Post([FromBody] Order newOrder)
        {
            return await orderBL.addNewOrder(newOrder);
        }

        //// PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //// DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderBL.deleteOrder(id);
        }
    }
}
