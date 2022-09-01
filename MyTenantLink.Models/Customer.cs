using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTenantLink.Models
{
    public class Customer : EntityBase
    {
        public string? Name { get; set; }

        public List<Building> Buildings { get; set; } = new List<Building>();
    }
}
