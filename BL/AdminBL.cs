//using AutoMapper.Configuration;
using DL;
using DTO;
using Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BL
{
    public class AdminBL : IAdminBL
    {
        IAdminDL adminDL;
        IConfiguration _configuration;
        public AdminBL(IAdminDL adminDL, IConfiguration configuration)
        {
            this.adminDL = adminDL;
            this._configuration = configuration;
        }

        //(post)
        public async Task<Admin> login(string name, string password)
        {
            Admin admin=await adminDL.login(name, password);
            if (admin == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, admin.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            admin.Token = tokenHandler.WriteToken(token);
            admin.Password = null;
            return admin;
        }

        //(post) 
        public async Task<int> addNewAdmin(Admin adminToAdd)
        {
            return await adminDL.addNewAdmin(adminToAdd);
        }

        //(put)
        public async Task updateAdmin(int id, Admin adminToUpdate)
        {
            await adminDL.updateAdmin(id, adminToUpdate);
        }
    }
}
