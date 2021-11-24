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
    public class EventsController : ControllerBase
    {
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // all events in month
        [HttpGet("{year/month}")]
        public List<Order> Get(int year, int month)
        {
            DateTime beginingOfMonth = new DateTime(year, month, 01);
            int days = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year,month,days);
            return null;
        }

        //all events in week
        [HttpGet("{date}")]
        public List<Order> Get(DateTime date)
        {
            DateTime beginingOfMonth = new DateTime(year, month, 01);
            int days = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year, month, days);
            return null;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
