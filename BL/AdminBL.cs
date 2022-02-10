﻿using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AdminBL : IAdminBL
    {
        IAdminDL adminDL;
        public AdminBL(IAdminDL adminDL)
        {
            this.adminDL = adminDL;
        }

        //(post)
        public async Task<Admin> login(string name, string password)
        {
            Admin admin=await adminDL.login(name, password);
            //להוסיף תוקן לאובייקט אדמין הזה
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