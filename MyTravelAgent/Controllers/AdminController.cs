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
    public class AdminController : ControllerBase
    {
        IAdminBL adminBL;
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }
        // GET: api/<AdminController>
        [HttpGet("{name}/{password}")]
        public async Task<Admin> Get(string name,string password)
        {
            return await adminBL.login(name, password);
        }

        // GET api/<AdminController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AdminController>
        [HttpPost]
        public async Task<int> Post([FromBody] Admin adminToAdd)
        {
            return await adminBL.addNewAdmin(adminToAdd);
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Admin adminToUpdate)
        {
            await adminBL.updateAdmin(id,adminToUpdate);
        }

        //// DELETE api/<AdminController>/5
        //[HttpDelete("{id}")]
        //public async Task Delete(int id)
        //{
            
        //}
    }
}
