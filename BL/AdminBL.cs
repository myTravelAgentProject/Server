//using AutoMapper.Configuration;
using DL;
using DTO;
using Entity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace BL
{
    public class AdminBL : IAdminBL
    {
        IAdminDL adminDL;
        IConfiguration _configuration;
        IPasswordHashHelper _passwordHashHelper;
        public AdminBL(IAdminDL adminDL, IConfiguration configuration, IPasswordHashHelper passwordHashHelper)
        {
            this.adminDL = adminDL;
            this._configuration = configuration;
            this._passwordHashHelper = passwordHashHelper;
        }

        //(post)
        public async Task<Admin> login(string name, string password)
        {

            Admin admin=await adminDL.login(name);
            string Hashedpassword = _passwordHashHelper.HashPassword(password, admin.Salt, 1000, 8);

            if (Hashedpassword.Equals(admin.Password.TrimEnd()) != true)
                return null;

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
            adminToAdd.Salt = _passwordHashHelper.GenerateSalt(8);
            adminToAdd.Password = _passwordHashHelper.HashPassword(adminToAdd.Password, adminToAdd.Salt, 1000, 8);
            return await adminDL.addNewAdmin(adminToAdd);
        }

        //(put)
        public async Task updateAdmin(int id, Admin adminToUpdate)
        {
            adminToUpdate.Salt = _passwordHashHelper.GenerateSalt(8);
            adminToUpdate.Password = _passwordHashHelper.HashPassword(adminToUpdate.Password, adminToUpdate.Salt, 1000, 8);
            await adminDL.updateAdmin(id, adminToUpdate);
        }
    }
}
