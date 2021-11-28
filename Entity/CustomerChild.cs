using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class CustomerChild
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
