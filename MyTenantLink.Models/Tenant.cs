

namespace MyTenantLink.Models
{
    public class Tenant : EntityBase
    {
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public List<Lease> Leases { get; set; } = new List<Lease>();
    }
}
