using Inventory_Project.Data;
using Inventory_Project.Repo.IRepo;

namespace Inventory_Project.Repo
{
    public class UnitOfWork:IUnitOfWork
        {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            customer = new CustomerRepo(context);
            productCategory = new ProductCategoryRepo(context);
            productUnit = new ProductUnitRepo(context);
            unit = new UnitRepo(context);
            supplier = new SupplierRepo(context);
            supplierProductRate = new SupplierProductRateRepo(context);
            product = new ProductRepo(context);
        }
        public ICustomerRepo customer { get; private set; }
        public IProductCategoryRepo productCategory { get; private set; }
        public IProductUnitRepo productUnit { get; private set; }
        public IUnitRepo unit { get; private set; }

        public ISupplierRepo supplier { get; private set; }

        public ISupplierProductRateRepo supplierProductRate { get; private set;}
        public IProductRepo product { get; private set;}
    }
}
