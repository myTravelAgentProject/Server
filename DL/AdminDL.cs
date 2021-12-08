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

        /*(get) looks for a admin that his email and password maches to the variables
        rerurns the object or null*/
        public async Task<Admin> login(string name, string password)
        {
            return await myContext.Admins.SingleOrDefaultAsync(a => a.Name == name && a.Password == password);
        }

        /*(post) add the new admin to the admin table
        then, save the changes
        and return its id (the id accepted from the datebase after insert)*/
        public async Task<int> addNewAdmin(Admin adminToAdd)
        {
            await myContext.Admins.AddAsync(adminToAdd);
            await myContext.SaveChangesAsync();
            return  adminToAdd.Id;
        }

        /*(put) finds the admin we want to change,
          then replace it with the new admin (the object after changes)
         save the changes*/
        public async Task updateAdmin(int id, Admin adminToUpdate)
        {
            Admin admin = await myContext.Admins.FindAsync(id);
            myContext.Entry(admin).CurrentValues.SetValues(adminToUpdate);
            await myContext.SaveChangesAsync();
        }
    }
}
