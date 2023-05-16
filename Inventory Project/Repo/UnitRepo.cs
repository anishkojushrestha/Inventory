using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Repo
{
    public class UnitRepo:Repo<Unit>, IUnitRepo
    {
        private ApplicationDbContext _context;

        public UnitRepo(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }
    }
}
