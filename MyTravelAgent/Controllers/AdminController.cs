using BL;
using DTO;
using Entity;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTravelAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AdminController : ControllerBase
    {
        IMapper mapper;
        IAdminBL adminBL;
        public AdminController(IAdminBL adminBL, IMapper mapper)
        {
            this.adminBL = adminBL;
            this.mapper = mapper;
        }
  
        //checks if has a admin with this email and password
        //returns the correct admin or null
        [HttpPost ("Login")]
        //[AllowAnonymous]
        public async Task<ActionResult<Admin>> post([FromBody] AdminDTO loginAdmin)
        {
            Admin admin= await adminBL.login(loginAdmin.Name, loginAdmin.Password);
            if (admin == null)
                return NoContent();
            else
                return Ok(admin);
             
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
