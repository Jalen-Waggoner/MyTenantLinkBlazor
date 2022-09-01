namespace MyTenantLink.Models;
public abstract class EntityBase
{
    public int Id { get; set; }
    public DateTime AddedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;

}
