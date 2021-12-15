using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderForCalendar
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string HotelName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public TimeSpan? EarlyCheckIn { get; set; }
        public TimeSpan? LateCheckOut { get; set; }

    }
}
