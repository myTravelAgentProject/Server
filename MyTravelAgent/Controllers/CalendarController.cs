using BL;
using DTO;
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
    public class CalendarController : ControllerBase
    {
        IOrderBL orderBL;
        IAlertBL alertBL;
        public CalendarController(IOrderBL orderBL, IAlertBL alertBL)
        {
            this.alertBL = alertBL;
            this.orderBL = orderBL;
        }

        /*calculate the first and the last dates in the month,
         goes to orderBL and gets a list of all the orders between those two dates
        returns the list*/
        [HttpGet("date/{year}/{month}/orders")]
        public async Task<List<OrderForCalendar>> getOrders( int year, int month)
        { 
            DateTime beginingOfMonth = new DateTime(year, month, 01);
            int days = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year,month,days);
            return await orderBL.getEventsForCalender(beginingOfMonth, endOfMonth);
           
        }

        /*calculate the first and the last dates in the week,
         goes to orderBL and gets a list of all the orders between those two dates
        returns the list*/
        [HttpGet ("date/{date}/orders")]
        public async Task<List<OrderForCalendar>> getOrders(DateTime date)
        {
            int dayOfWeek = (int)date.DayOfWeek;
            DateTime beginingOfWeek = date.AddDays(-dayOfWeek+1);
            DateTime endOfWeek = beginingOfWeek.AddDays(6);
            return await orderBL.getEventsForCalender(beginingOfWeek, endOfWeek);
        }

        /*calculate the first and the last dates in the month,
         goes to alertBL and gets a list of all the alerts between those two dates
        returns the list*/
        [HttpGet("date/{year}/{month}/alerts")]
        public async Task<List<Alert>> getAlerts(int year, int month)
        {
            DateTime beginingOfMonth = new DateTime(year, month, 01);
            int days = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year, month, days);
            return await alertBL.getAlertsForCalender(beginingOfMonth, endOfMonth);
        }

        /*calculate the first and the last dates in the week,
         goes to alertBL and gets a list of all the alerts between those two dates
        returns the list*/
        [HttpGet("date/{date}/alerts")]
        public async Task<List<Alert>> getAlerts(DateTime date)
        {
            int dayOfWeek = (int)date.DayOfWeek;
            DateTime beginingOfWeek = date.AddDays(-dayOfWeek + 1);
            DateTime endOfWeek = beginingOfWeek.AddDays(6);
            return await alertBL.getAlertsForCalender(beginingOfWeek, endOfWeek);
        }
    }
}
