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
        [EmailAddress]
        public string Name { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
     
        [NotMapped]
        public string Token { get; set; }
    }
}
