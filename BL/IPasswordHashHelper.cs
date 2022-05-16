using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IPasswordHashHelper
    {
        string GenerateSalt(int nSalt);
        string HashPassword(string password, string salt, int nIterations, int nHash);
    }
}
