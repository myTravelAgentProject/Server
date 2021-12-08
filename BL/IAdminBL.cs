﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IAdminBL
    {
        public Task<Admin> login(string name, string password);
        public Task<int> addNewAdmin(Admin adminToAdd);
        public Task updateAdmin(int id,Admin adminToUpdate);
    }
}
