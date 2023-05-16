using Inventory_Project.Data;
using Inventory_Project.Repo.IRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Inventory_Project.Repo
{
    public class Repo<T> : IRepo<T> where T : class, IBaseRepo, new()
    {
        private readonly ApplicationDbContext _context;
        public Repo(ApplicationDbContext context)
        {
            _context = context;
            this._context.suppliersProductsRate.Include(x => x.Unit);
            this._context.productUnits.Include(x => x.Product);
            this._context.products.Include(x => x.Category).Include(x => x.Unit);
        }

        public async Task AddAsync(T enitiy)
        {
            await _context.Set<T>().AddAsync(enitiy);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(data);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> data = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var inc in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    data = data.Include(inc);
                }
            }
            return data.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> data = _context.Set<T>();
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}   