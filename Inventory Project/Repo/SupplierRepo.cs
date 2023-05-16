using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Repo
{
    public class SupplierRepo: Repo<Supplier>, ISupplierRepo
    {
        private ApplicationDbContext _context;
        public SupplierRepo(ApplicationDbContext _context) : base(_context)
        {
            this._context = _context;
        }
    }
}
