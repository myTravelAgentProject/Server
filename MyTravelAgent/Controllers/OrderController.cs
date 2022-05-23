using AutoMapper;
using BL;
using DTO;
using Entity;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class OrderController : ControllerBase
    {
        IOrderBL orderBL;
        IMapper mapper;
        public OrderController(IOrderBL orderBL, IMapper mapper)
        {
            this.orderBL = orderBL;
            this.mapper = mapper;
        }

        //return all the orders that their price had change (the 'change' filed is true)
        [HttpGet ("ChangedPriceOrders")]
        public async Task<List<OrderDTO>> GetChangePriceOrders()
        {
            List<Order> orders=await orderBL.getAllChanges();
            List<OrderDTO> ordersDTO= mapper.Map<List<Order>, List<OrderDTO>>(orders);
            return ordersDTO;
        }

        [HttpGet("ordersToCheck")]
        public async Task<List<OrderDTO>> GetOredersToCheck()
        {
            List<Order> orders=await orderBL.getOrsersToCheck(DateTime.Now);
            List<OrderDTO> ordersDTO= mapper.Map<List<Order>, List<OrderDTO>>(orders);
            return ordersDTO;
        }
        // return a order according to its id
        [HttpGet("{id}")]
        public async Task<OrderDTO> getOrderById(int id)
        {
            Order order = await orderBL.getOrderById(id);
            OrderDTO orderDTO = mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }


        /*return a list of 15 last taching orders*/
        [HttpGet ("lastOrders")]
        public async Task<List<OrderDTO>> getTheLastOrders()
         {
            List<Order> orders = await orderBL.getTheLastOrders();
            List<OrderDTO> ordersDTO = mapper.Map<List<Order>, List<OrderDTO>>(orders);
            return ordersDTO;
        }

        [HttpGet]
        public async Task<List<OrderDTO>> getOrdersByQeryParams(string customerName="",string hotelName = "", string startDate=null,string endDate=null)
        {
            List<Order> orders = await orderBL.getOrdersByQeryParams(customerName, hotelName,startDate,endDate);
            List<OrderDTO> ordersDTO = mapper.Map<List<Order>, List<OrderDTO>>(orders);
            return ordersDTO;
        }

        //get orders between two dates
        //[HttpGet("betweenDates/{start}/{end}")]
        //public async Task<List<OrderDTO>> Get(DateTime start, DateTime end)
        //{
        //    List<Order> orders = await orderBL.getOrdetsBetweenDates(start, end);
        //    List<OrderDTO> ordersDTO = mapper.Map<List<Order>, List<OrderDTO>>(orders);
        //    return ordersDTO; 
        //}

        //add a order
        [HttpPost]
        public async Task<int> Post([FromBody] OrderDTO newOrder)
        {
            Order _order = mapper.Map<OrderDTO, Order>(newOrder);
            return await orderBL.addNewOrder(_order);
        }

        //update a order according to the given id
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] OrderDTO orderToUpdate)
        {

            Order _orderToUpdate = mapper.Map<OrderDTO, Order>(orderToUpdate);
            await orderBL.updateOrder(_orderToUpdate, id);
        }

        //delete a order according to the id
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await orderBL.deleteOrder(id);
        }
    }
}
