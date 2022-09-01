using System.Threading.Tasks;
using MyTenantLink.Data;
using MyTenantLink.Services.Repo.Interfaces;

namespace MyTenantLink.Services.Repo
{
    public class Repo : IRepo
    {
        private readonly AppDbContext _context;

        public Repo(AppDbContext context)
        {
            _context = context;
            this.Building = new BuildingRepo(_context);
            this.Customer = new CustomerRepo(_context);
            this.Lease = new LeaseRepo(_context);
            this.Tenant = new TenantRepo(_context);
            this.Unit = new UnitRepo(_context);
            this.Transaction = new TransactionRepo(_context);
        }


        public BuildingRepo Building { get; set; }
        public CustomerRepo Customer { get; set; }
        public LeaseRepo Lease { get; set; }
        public TenantRepo Tenant { get; set; }
        public UnitRepo Unit { get; set; }
        public TransactionRepo Transaction { get; set; }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
