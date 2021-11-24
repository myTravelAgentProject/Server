using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Request
    {
        public int RequestId { get; set; }
        public int CustomerId { get; set; }
        public int? Price { get; set; }
        public string Area { get; set; }
        public DateTime? ArriveDate { get; set; }
        public DateTime? LeavingDate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
