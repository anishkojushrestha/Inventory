using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_Project.Controllers
{
    public class SupplierProductRateController : Controller
    {
        private readonly IUnitOfWork _context;

        public SupplierProductRateController(IUnitOfWork context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SupplierProductRate> data = _context.supplierProductRate.GetAll(includeProperties: "Unit");
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["UnitId"] = new SelectList(await _context.unit.GetAllAsync(), "Id", "UnitName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierProductRate supplierProductRate)
        {
            if (ModelState.IsValid)
            {
                await _context.supplierProductRate.AddAsync(supplierProductRate);

                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _context.supplierProductRate.GetByIdAsync(id);

            if (data == null)
            {
                return View(NotFound());
            }
            ViewData["UnitId"] = new SelectList(await _context.unit.GetAllAsync(), "Id", "UnitName");
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SupplierProductRate supplierProductRate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SupplierProductRate? data = await _context.supplierProductRate.GetByIdAsync(id);
                    if (data == null) { return View(NotFound()); }
                    data.UnitId = supplierProductRate.UnitId;
                    data.Rate = supplierProductRate.Rate;
                    await _context.supplierProductRate.UpdateAsync(id, data);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(supplierProductRate);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.supplierProductRate.GetByIdAsync(id);
            if (data == null)
            {
                return View();
            }
            await _context.supplierProductRate.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
