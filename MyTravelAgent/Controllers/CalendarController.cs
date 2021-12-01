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
    public class EventsController : ControllerBase
    {
       
        IOrderBL orderBL;
        IAlertBL alertBL;
        public EventsController(IOrderBL orderBL, IAlertBL alertBL)
        {
            this.alertBL = alertBL;
            this.orderBL = orderBL;
        }
        // GET: api/<EventsController>
        //[HttpGet]
        //public void Get()
        //{
        //    Console.WriteLine("hi");
        //}

        // all events in month
        [HttpGet("[action]/{year}/{month}")]
        public async Task<List<OrderForCalendar>> getOrders( int year, int month)
        { 
            DateTime beginingOfMonth = new DateTime(year, month, 01);
            int days = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year,month,days);
            return await orderBL.getEventsForCalender(beginingOfMonth, endOfMonth);
           
        }

        //all events in week
        [HttpGet("[action]/{date}")]
        public async Task<List<OrderForCalendar>> getOrders(DateTime date)
        {
            int dayOfWeek = (int)date.DayOfWeek;
            DateTime beginingOfWeek = date.AddDays(-dayOfWeek+1);
            DateTime endOfWeek = beginingOfWeek.AddDays(6);
            return await orderBL.getEventsForCalender(beginingOfWeek, endOfWeek);
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // all alerts in month
        [HttpGet]
        [Route("[action]/{year}/{month}")]
        public async Task<List<Alert>> getAlerts(int year, int month)
        {
            DateTime beginingOfMonth = new DateTime(year, month, 01);
            int days = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year, month, days);
            return await alertBL.getAlertsForCalender(beginingOfMonth, endOfMonth);
        }

        //all events in week
        [HttpGet]
        [Route("[action]/{date}")]
        public async Task<List<Alert>> getAlerts(DateTime date)
        {
            int dayOfWeek = (int)date.DayOfWeek;
            DateTime beginingOfWeek = date.AddDays(-dayOfWeek + 1);
            DateTime endOfWeek = beginingOfWeek.AddDays(6);
            return await alertBL.getAlertsForCalender(beginingOfWeek, endOfWeek);
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
