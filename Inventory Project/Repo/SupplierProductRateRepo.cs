using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Repo
{
    public class SupplierProductRateRepo : Repo<SupplierProductRate>, ISupplierProductRateRepo
    {
        private ApplicationDbContext _context;

        public SupplierProductRateRepo(ApplicationDbContext _context) : base(_context)
        {
            this._context = _context;
        }
    }
}
