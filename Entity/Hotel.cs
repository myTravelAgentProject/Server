using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Hotel
    {
        public Hotel()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
