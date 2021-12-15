using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class customerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? NumOfAdults { get; set; }
        public int? NumOfKids { get; set; }
        public bool? HighFloor { get; set; }
        public bool? Porch { get; set; }
        public bool? SeprateBeds { get; set; }
        public bool? MultipleRooms { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Comments { get; set; }
    }
}
