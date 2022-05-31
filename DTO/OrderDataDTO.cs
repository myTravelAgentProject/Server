using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDataList
    {
        public List<OrderDTO> Orders { get; set; }
        public int TotalRows { get; set; }
    }
}
