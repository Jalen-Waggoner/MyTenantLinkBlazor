using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Models;
using System.Linq.Expressions;

namespace MyTenantLink.Services.Repo
{
    public class LeaseRepo
    {
        private AppDbContext _context;

        public LeaseRepo(AppDbContext context)
        {
            _context = context;
        }

        public int ClientId { get; set; }


        public async Task<Lease> GetByIdAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Lease.FindAsync(id);
        }

        public async Task<Lease> GetByIdWithCustomerTenantAndUnitAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Lease
                .Include(l => l.Customer)
                .Include(l => l.Tenant)
                .Include(l => l.Unit)
                .FirstOrDefaultAsync(l => l.Id ==id);
        }

        public async Task<IList<Lease>> GetAllAsync()
        {
            return await _context.Lease.ToListAsync();
        }

        public async Task<IList<Lease>> GetAllWithCustomersAsync()
        {
            return await _context.Lease
                .Include(t => t.Customer)
                .ToListAsync();
        }

        public async Task<IList<Lease>> GetAllWithCustomersTenantsAndUnitsAsync()
        {
            return await _context.Lease
                .Include(l => l.Customer)
                .Include(l => l.Tenant)
                .Include(l => l.Unit)
                .ToListAsync();
        }

        public IEnumerable<Lease> FindAsync(Expression<Func<Lease, bool>> predicate)
        {
            return _context.Lease.Where(predicate);
        }

        public async Task<Lease> SingleOrDefaultAsync(Expression<Func<Lease, bool>> predicate)
        {
            return await _context.Lease.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(Lease entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;
            entityBase.AddedDate = DateTime.Now;

            await _context.Lease.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<Lease> entities)
        {
            await _context.Lease.AddRangeAsync(entities);
        }

        public void Delete(Lease entity)
        {
            _context.Lease.Remove(entity);
        }

        public void DeleteRange(IList<Lease> entities) => _context.Lease.RemoveRange(entities);

        public void Update(Lease entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;

            _context.Lease.Attach(entity).State = EntityState.Modified;
        }

    }
}
