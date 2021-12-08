using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTravelAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingBL BookingBL;
        public BookingController(IBookingBL BookingBL)
        {
            this.BookingBL = BookingBL;
        }
        // GET: api/<BookingController>
        [HttpGet ("updateOrders")]
        public  async Task updateOrders()
        {
            await  BookingBL.updateOrders();
        }

        //// GET api/<BookingController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<BookingController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BookingController>/5
        //[HttpPut("{id}")]
        //public async Task Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BookingController>/5
        //[HttpDelete("{id}")]
        //public async Task Delete(int id)
        //{
        //}
    }
}
