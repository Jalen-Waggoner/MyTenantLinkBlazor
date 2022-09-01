using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Models;
using System.Linq.Expressions;

namespace MyTenantLink.Services.Repo
{
    public class CustomerRepo {
    private AppDbContext _context;

    public CustomerRepo(AppDbContext context) {
      _context = context;
    }

    public int ClientId { get; set; }


    public async Task<Customer> GetByIdAsync(int? id) {
      
      if(id == null)
        throw new ArgumentNullException(nameof(id));
      
      return await _context.Customer.FindAsync(id);
    }

        public async Task<Customer> GetByIdWithBuilingsAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Customer.Include(c => c.Buildings)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Customer>> GetAllAsync() {
      return await _context.Customer.ToListAsync();
    }

    public IEnumerable<Customer> FindAsync(Expression<Func<Customer, bool>> predicate) {
      return _context.Customer.Where(predicate);
    }

    public async Task<Customer> SingleOrDefaultAsync(Expression<Func<Customer, bool>> predicate) {
      return await _context.Customer.SingleOrDefaultAsync(predicate);
    }

    public async Task AddAsync(Customer entity) {

      var entityBase = entity as EntityBase;
      entityBase.UpdatedDate = DateTime.Now;
      entityBase.AddedDate = DateTime.Now;

      await _context.Customer.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<Customer> entities) {
      await _context.Customer.AddRangeAsync(entities);
    }

    public void Delete(Customer entity) {
      _context.Customer.Remove(entity);
    }

    public void DeleteRange(IList<Customer> entities) => _context.Customer.RemoveRange(entities);

    public void Update(Customer entity) {

      var entityBase = entity as EntityBase;
      entityBase.UpdatedDate = DateTime.Now;

      _context.Customer.Attach(entity).State = EntityState.Modified;
    }

  }
}
