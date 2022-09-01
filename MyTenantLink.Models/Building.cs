
using MyTenantLink.Models.Enums;

namespace MyTenantLink.Models;

public class Building : EntityBase
{
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public string? BuildingCode { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public State State { get; set; }
    public int Zip { get; set; }

    public string Name => $"{BuildingCode} {Street}";
    public List<Unit> Units { get; set; } = new List<Unit>();
    
    
}

