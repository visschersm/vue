using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Installation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
    }
}
