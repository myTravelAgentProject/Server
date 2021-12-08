using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class AdminDL : IAdminDL
    {
        MyTravelAgentContext myContext;
        public AdminDL(MyTravelAgentContext myContext)
        {
            this.myContext = myContext;
        }

        public async Task<int> addNewAdmin(Admin adminToAdd)
        {
            await myContext.Admins.AddAsync(adminToAdd);
            await myContext.SaveChangesAsync();
            return  adminToAdd.Id;
        }

        public async Task<Admin> login(string name, string password)
        {
            return await myContext.Admins.SingleOrDefaultAsync(a => a.Name == name && a.Password == password);
        }

        public async Task updateAdmin(int id, Admin adminToUpdate)
        {
            Admin admin = await myContext.Admins.FindAsync(id);
            myContext.Entry(admin).CurrentValues.SetValues(adminToUpdate);
            await myContext.SaveChangesAsync();
        }
    }
}
