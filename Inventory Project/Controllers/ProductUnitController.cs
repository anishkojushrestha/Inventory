using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_Project.Controllers
{
    public class ProductUnitController : Controller
    {
        private readonly IUnitOfWork _context;

        public ProductUnitController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductUnit> data = _context.productUnit.GetAll(includeProperties: "Product");
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            ViewData["ProductId"] = new SelectList(await _context.product.GetAllAsync(), "Id", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductUnit productUnit)
        {
            if (ModelState.IsValid)
            {
                await _context.productUnit.AddAsync(productUnit);
                
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _context.productUnit.GetByIdAsync(id);

            if (data == null)
            {
                return View(NotFound());
            }
            ViewData["ProductId"] = new SelectList(await _context.product.GetAllAsync(), "Id", "ProductName");
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductUnit productUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductUnit? data = await _context.productUnit.GetByIdAsync(id);
                    if (data == null) { return View(NotFound()); }
                    data.UnitRate = productUnit.UnitRate;
                    data.isDefault = productUnit.isDefault;
                    data.UnitId = productUnit.UnitId;
                    await _context.productUnit.UpdateAsync(id, data);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(productUnit);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.productUnit.GetByIdAsync(id);
            if (data == null)
            {
                return View();
            }
            await _context.productUnit.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
