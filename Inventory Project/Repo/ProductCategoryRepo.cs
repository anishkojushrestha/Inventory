using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Repo
{
    public class ProductCategoryRepo:Repo<ProductCategory>,IProductCategoryRepo
    {
        private ApplicationDbContext _context;

        public ProductCategoryRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
