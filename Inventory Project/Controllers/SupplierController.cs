using Inventory_Project.Data;
using Inventory_Project.Migrations;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Inventory_Project.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly ApplicationDbContext _dbContext;
        public SupplierController(IUnitOfWork _context, ApplicationDbContext dbContext)
        {
            this._context = _context;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Supplier> data = await _context.supplier.GetAllAsync();
            return View(data);
        }
        private void AddEditCommon(Supplier Data)
        {
            ViewBag.ProductId = new SelectList(_dbContext.products.AsNoTracking().ToList(), "Id", "ProductName");
        }
        public IActionResult Create()
        {
            AddEditCommon(new Supplier());
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            //if (ModelState.IsValid)
            //{
            //    await _context.supplier.AddAsync(supplier);
            //}
            var units = new Unit()
            {
                UnitName = "kg",
                BaseRatio = 1
            };
            await _context.unit.AddAsync(units);

            var productCategorires = new ProductCategory()
            {
                CategoryName = "Stationary"
            };
            await _context.productCategory.AddAsync(productCategorires);

            //var products = new Product()
            //{
            //    ProductName = "Book",
            //    UnitId = units.Id,
            //    UnitPrice = 100,
            //    CategoryId = productCategorires.Id,
            //};
            //await _context.product.AddAsync(products);

            await _context.supplier.AddAsync(new Supplier()
            {
                ContactName = supplier.ContactName,
                CompanyName = supplier.CompanyName,
                Address = supplier.Address,
                CreatedDate = DateTime.Now,
                PhoneNumber = supplier.PhoneNumber,
                SupplierProduct = new List<SupplierProduct>()
                {
                    new SupplierProduct()
                    {
                        ProductId= 2,
                        SupplierId = supplier.Id,
                    }
                }
            });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _context.supplier.GetByIdAsync(id);

            if (data == null)
            {
                return View(NotFound());
            }
            AddEditCommon(data);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Supplier? data = await _context.supplier.GetByIdAsync(supplier.Id);
                    if (data == null) { return View(NotFound()); }

                    data.CompanyName = supplier.CompanyName;
                    data.ContactName = supplier.ContactName;
                    data.Address = supplier.Address;
                    data.PhoneNumber = supplier.PhoneNumber;
                    await _context.supplier.UpdateAsync(supplier.Id, data);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            AddEditCommon(supplier);
            return View(supplier);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.supplier.GetByIdAsync(id);
            if (data == null)
            {
                return View();
            }

            await _context.supplier.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateBulk()
        {
            AddEditCommon(new Supplier());
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBulk(ABCViewModel Data)
        {
            var u1 = new Unit()
            {
                UnitName = Data.Name,
                BaseRatio = 1
            };
            await _context.unit.AddAsync(u1);
            var c1 = new ProductCategory()
            {
                CategoryName = Data.Name
            };
            await _context.productCategory.AddAsync(c1);
            var p1 = new Product()
            {
                ProductName = Data.Name,
                UnitId = u1.Id,
                UnitPrice = 100,
                CategoryId = c1.Id,
            };
            await _context.product.AddAsync(p1);

            await _context.supplier.AddAsync(new Supplier()
            {
                ContactName = Data.Name,
                CompanyName = Data.Name,
                Address = Data.Address,
                CreatedDate = DateTime.Now,
                PhoneNumber = Data.Mobile,
                SupplierProduct = new List<SupplierProduct>()
                {
                    new SupplierProduct()
                    {
                        ProductId= p1.Id
                    }
                }
            });


            //await _context.supplier.AddAsync(supplier);
            return RedirectToAction("Index");
        }

    }

    public class ABCViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        //public int[] ProdIds { get; set; }
        //public List<int> ProdIds { get; set; }
        public ICollection<int> ProdIds { get; set; }
        public ICollection<int> ProdRate { get; set; }
        //one to one relation format [FK]
        public XYZModel Data { get; set; }
        //One to many relation format [FK]
        public ICollection<XYZModel> DataList { get; set; }
    }
    public class XYZModel
    {
        public string ChildName { get; set; }
        public string ChildAdd { get; set; }
        public string ChildMobile { get; set; }
    }
}
