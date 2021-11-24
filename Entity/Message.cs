using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Message
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; }
        public bool? AlredyRead { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
