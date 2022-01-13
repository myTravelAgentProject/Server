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
    public class AlertController : ControllerBase
    {
        public IAlertBL alertBL;

        public AlertController(IAlertBL alertBL)
        {
            this.alertBL = alertBL;
        }

        //returns all the relevants alerts that their date passed
        [HttpGet ("{date}")]
        public async Task<List<Alert>> Get(DateTime date)
        {
            return await alertBL.getRelevantAlerts(date);
        }

        //add new alert
        [HttpPost]
        public async Task<int> Post([FromBody] Alert newAlert)
        {
            return await alertBL.insertAlert(newAlert);
        }

        //update the date of the alert according to the id
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Alert alertToUpdate)
        {
            await alertBL.updateAlert(id,alertToUpdate);
        }

        //delete alert (the message alert have be done)
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await alertBL.deleteAlert(id);
        }
    }
}
