using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Models;
using System.Linq.Expressions;

namespace MyTenantLink.Services.Repo
{
    public class TransactionRepo
    {
        private AppDbContext _context;

        public TransactionRepo(AppDbContext context)
        {
            _context = context;
        }

        public int ClientId { get; set; }


        public async Task<Transaction> GetByIdAsync(int? id)
        {

            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Transaction.FindAsync(id);
        }

        public async Task<IList<Transaction>> GetAllAsync()
        {
            return await _context.Transaction.ToListAsync();
        }

  
        public IEnumerable<Transaction> FindAsync(Expression<Func<Transaction, bool>> predicate)
        {
            return _context.Transaction.Where(predicate);
        }

        public async Task<Transaction> SingleOrDefaultAsync(Expression<Func<Transaction, bool>> predicate)
        {
            return await _context.Transaction.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(Transaction entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;
            entityBase.AddedDate = DateTime.Now;

            await _context.Transaction.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<Transaction> entities)
        {
            await _context.Transaction.AddRangeAsync(entities);
        }

        public void Delete(Transaction entity)
        {
            _context.Transaction.Remove(entity);
        }

        public void DeleteRange(IList<Transaction> entities) => _context.Transaction.RemoveRange(entities);

        public void Update(Transaction entity)
        {

            var entityBase = entity as EntityBase;
            entityBase.UpdatedDate = DateTime.Now;

            _context.Transaction.Attach(entity).State = EntityState.Modified;
        }

    }
}
