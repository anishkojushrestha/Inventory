using Inventory_Project.Data;
using Inventory_Project.Migrations;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Inventory_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _context;
        public ProductController(IUnitOfWork _context)
        {
            this._context = _context;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Product> data = _context.product.GetAll(includeProperties: "Category,Unit");

            return View(data);
        }

        public async Task<IActionResult> Create(int? Id)
        {
            ViewData["CategoryId"] = new SelectList(await _context.productCategory.GetAllAsync(), "Id", "CategoryName");
            ViewData["UnitId"] = new SelectList(await _context.unit.GetAllAsync(), "Id", "UnitName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.product.AddAsync(product);

            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _context.product.GetByIdAsync(id);
            if (data == null)
            {
                return View(NotFound());
            }
            ViewData["CategoryId"] = new SelectList(await _context.productCategory.GetAllAsync(), "Id", "CategoryName");
            ViewData["UnitId"] = new SelectList(await _context.unit.GetAllAsync(), "Id", "UnitName");
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                var data = await _context.product.GetByIdAsync(id);
                if (data == null) { return View(NotFound()); }
                data.ProductName = product.ProductName;
                data.UnitPrice = product.UnitPrice;
                data.CategoryId = product.CategoryId;
                data.UnitId = product.UnitId;
                await _context.product.UpdateAsync(id, data);

            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var data = await _context.product.GetByIdAsync(id);
                if (data == null)
                {
                    throw new Exception("Invalid Ref Id. Plz Check");
                }
                return View(data);
            }
            catch (Exception ex)
            {
                //error log should be added
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _context.product.GetByIdAsync(id);
                ViewData["CategoryId"] = new SelectList(await _context.productCategory.GetAllAsync(), "Id", "CategoryName");
                ViewData["UnitId"] = new SelectList(await _context.unit.GetAllAsync(), "Id", "UnitName");
                if (data == null)
                {
                    throw new Exception("Invalid Ref Id. Plz Check");
                }
                return View(data);
            }
            catch (Exception ex)
            {
                //error log should be added
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Product product)
        {
            var data = await _context.product.GetByIdAsync(id);
            if (data == null)
            {
                return View();
            }
            ViewData["CategoryId"] = new SelectList(await _context.productCategory.GetAllAsync(), "Id", "CategoryName");
            ViewData["UnitId"] = new SelectList(await _context.unit.GetAllAsync(), "Id", "UnitName");
            await _context.product.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
