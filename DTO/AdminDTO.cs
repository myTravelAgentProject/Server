using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class AdminDTO
    {
        
        public string Name { get; set; }
        
        public string Password { get; set; }
   
    }
}
