using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Models;
using System.Linq.Expressions;

namespace MyTenantLink.Services.Repo
{
    public class TenantRepo
    {
        private AppDbContext _context;

        public TenantRepo(AppDbContext context)
        {
            _context = context;
        }

        public int ClientId { get; set; }


        public async Task<Tenant> GetByIdAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Tenant.FindAsync(id);
        }

        public async Task<IList<Tenant>> GetAllAsync()
        {
            return await _context.Tenant.ToListAsync();
        }

        public async Task<IList<Tenant>> GetAllWithCustomersAsync()
        {
            return await _context.Tenant
                .Include(t => t.Customer)
                .ToListAsync();
        }

        public IEnumerable<Tenant> FindAsync(Expression<Func<Tenant, bool>> predicate)
        {
            return _context.Tenant.Where(predicate);
        }

        public async Task<Tenant> SingleOrDefaultAsync(Expression<Func<Tenant, bool>> predicate)
        {
            return await _context.Tenant.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(Tenant entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;
            entityBase.AddedDate = DateTime.Now;

            await _context.Tenant.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<Tenant> entities)
        {
            await _context.Tenant.AddRangeAsync(entities);
        }

        public void Delete(Tenant entity)
        {
            _context.Tenant.Remove(entity);
        }

        public void DeleteRange(IList<Tenant> entities) => _context.Tenant.RemoveRange(entities);

        public void Update(Tenant entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;

            _context.Tenant.Attach(entity).State = EntityState.Modified;
        }

    }
}
