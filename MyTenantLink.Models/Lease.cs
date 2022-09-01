

using MyTenantLink.Models.Enums;

namespace MyTenantLink.Models
{
    public class Lease : EntityBase
    { 
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public Period Period { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
