

namespace MyTenantLink.Models
{
    public class Unit : EntityBase
    {
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int BuildingId { get; set; }
        public Building? Building { get; set; }
        public decimal Rate { get; set; }
        public string? UnitCode { get; set; }
        public List<Lease> Leases { get; set; } = new List<Lease>();
    }
}
