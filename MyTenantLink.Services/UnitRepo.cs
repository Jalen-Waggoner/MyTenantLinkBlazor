using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Models;
using System.Linq.Expressions;

namespace MyTenantLink.Services.Repo
{
    public class UnitRepo
    {
        private AppDbContext _context;

        public UnitRepo(AppDbContext context)
        {
            _context = context;
        }

        public int ClientId { get; set; }


        public async Task<Unit> GetByIdAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Unit.FindAsync(id);
        }

        public async Task<Unit> GetByIdWithBuildingsAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Unit.Include(u => u.Building).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IList<Unit>> GetAllAsync()
        {
            return await _context.Unit.ToListAsync();
        }

        public async Task<IList<Unit>> GetAllWithCustomersAsync()
        {

            var unit = await _context.Unit
                .Include(t => t.Customer)
                .ToListAsync();

            unit = await _context.Unit
                .Include(t => t.Building)
                .ToListAsync();
            return unit;
            
        }

        public IEnumerable<Unit> FindAsync(Expression<Func<Unit, bool>> predicate)
        {
            return _context.Unit.Where(predicate);
        }

        public async Task<Unit> SingleOrDefaultAsync(Expression<Func<Unit, bool>> predicate)
        {
            return await _context.Unit.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(Unit entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;
            entityBase.AddedDate = DateTime.Now;

            await _context.Unit.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<Unit> entities)
        {
            await _context.Unit.AddRangeAsync(entities);
        }

        public void Delete(Unit entity)
        {
            _context.Unit.Remove(entity);
        }

        public void DeleteRange(IList<Unit> entities) => _context.Unit.RemoveRange(entities);

        public void Update(Unit entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;

            _context.Unit.Attach(entity).State = EntityState.Modified;
        }

    }
}
