using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class CustomerChild
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
    }
}
