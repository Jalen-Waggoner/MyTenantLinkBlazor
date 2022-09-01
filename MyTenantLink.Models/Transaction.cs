using MyTenantLink.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTenantLink.Models
{
    public class Transaction :EntityBase
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public Period Period { get; set; }

        public Lease? Lease { get; set; }

        public int LeaseId { get; set; }



    }
}
