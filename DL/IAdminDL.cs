using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IAdminDL
    {
        //(get)
        public Task<Admin> login(string name, string password);
        //(post)
        public Task<int> addNewAdmin(Admin adminToAdd);
        //(put)
        public Task updateAdmin(int id,Admin adminToUpdate);
    }
}
