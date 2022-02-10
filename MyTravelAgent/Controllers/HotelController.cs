using BL;
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
    public class HotelController : ControllerBase
    {
        IHotelBL hotelBL;
        public HotelController(IHotelBL hotelBL)
        {
            this.hotelBL = hotelBL;
        }

        // returns all the hotels list
        [HttpGet]
        public async Task<List<Hotel>> Get()
        {
            return await hotelBL.GetHotelsList();
        }

        //add new hotel
        [HttpPost]
        public async Task<int> Post([FromBody] Hotel newHotel)
        {
            return await hotelBL.addNewHotel(newHotel);
        }

        //delete a hotel from the hotel table 
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await hotelBL.deleteHotel(id);
        }
    }
}
