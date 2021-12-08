using DL;
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

        //(get)
        public async Task<Admin> login(string name, string password)
        {
            return await adminDL.login(name, password);
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
