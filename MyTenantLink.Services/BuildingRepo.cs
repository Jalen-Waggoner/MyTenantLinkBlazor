using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Models;
using System.Linq.Expressions;

namespace MyTenantLink.Services.Repo
{
    public class BuildingRepo
    {
        private AppDbContext _context;

        public BuildingRepo(AppDbContext context)
        {
            _context = context;
        }

        public int ClientId { get; set; }


        public async Task<Building> GetByIdAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Building.FindAsync(id);
        }

        public async Task<Building> GetByIdWithCustomersAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Building
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Building> GetByIdWithCustomersAndUnitsAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Building
                .Include(b => b.Customer)
                .Include(b => b.Units)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IList<Building>> GetAllAsync()
        {
            return await _context.Building.ToListAsync();
        }

        public async Task<IList<Building>> GetAllWithCustomersAsync()
        {
            return await _context.Building
                .Include(t => t.Customer)
                .ToListAsync();
        }

        public IEnumerable<Building> FindAsync(Expression<Func<Building, bool>> predicate)
        {
            return _context.Building.Where(predicate);
        }

        public async Task<Building> SingleOrDefaultAsync(Expression<Func<Building, bool>> predicate)
        {
            return await _context.Building.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(Building entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;
            entityBase.AddedDate = DateTime.Now;

            await _context.Building.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<Building> entities)
        {
            await _context.Building.AddRangeAsync(entities);
        }

        public void Delete(Building entity)
        {
            _context.Building.Remove(entity);
        }

        public void DeleteRange(IList<Building> entities) => _context.Building.RemoveRange(entities);

        public void Update(Building entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;

            _context.Building.Attach(entity).State = EntityState.Modified;
        }

    }
}
