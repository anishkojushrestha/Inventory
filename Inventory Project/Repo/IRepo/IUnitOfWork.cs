namespace Inventory_Project.Repo.IRepo
{
    public interface IUnitOfWork
    {
        ICustomerRepo customer { get; }
        IProductCategoryRepo productCategory { get; }
        IProductUnitRepo productUnit { get; }
        IUnitRepo unit { get; }
        ISupplierRepo supplier { get; }

        ISupplierProductRateRepo supplierProductRate { get; }
        IProductRepo product { get; }
    }
}
