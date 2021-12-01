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
    public class HotelController : ControllerBase
    {
        IHotelBL hotelBL;
        public HotelController(IHotelBL hotelBL)
        {
            this.hotelBL = hotelBL;
        }
        // GET: api/<HotelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HotelController>/5
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return "value";
        }

        //POST api/<HotelController>
        //[HttpPost]
        //public async Task<int> Post([FromBody] Hotel newHotel)
        //{
        //    return await hotelBL.addNewHotel(newHotel);
        //}

        // PUT api/<HotelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
