using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Entity
{
    public partial class Admin
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Name { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        //public string Token { get; set; }
    }
}
