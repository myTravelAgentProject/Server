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
    public class AdminController : ControllerBase
    {
        IAdminBL adminBL;
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }
        //checks if has a admin with this email and password
        //returns the correct admin or null
        [HttpPost ("Login")]
        public async Task<AdminDTO> post([FromBody] Admin admin)
        {
            return await adminBL.login(admin.Name, admin.Password);
        }


        //insert a new admin (can be called only after sign in to the site)
        [HttpPost]
        public async Task<int> Post([FromBody] Admin adminToAdd)
        {
            return await adminBL.addNewAdmin(adminToAdd);
        }

        //apdates the details of the current admin (can be only after login)
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Admin adminToUpdate)
        {
            await adminBL.updateAdmin(id,adminToUpdate);
        }
    }
}
