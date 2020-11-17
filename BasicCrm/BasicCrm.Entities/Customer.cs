using System;
using System.Collections.Generic;
using System.Text;

namespace BasicCrm.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
