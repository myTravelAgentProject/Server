using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Request
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? Price { get; set; }
        public string Area { get; set; }
        public DateTime? ArriveDate { get; set; }
        public DateTime? LeavingDate { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
    }
}
