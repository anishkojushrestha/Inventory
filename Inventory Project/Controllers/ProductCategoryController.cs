using Inventory_Project.Data;
using Inventory_Project.Migrations;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Project.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoryController(IUnitOfWork _context, ApplicationDbContext dbContext)
        {
            this._context = _context;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductCategory> data;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ProductCategory").Result;
            data = response.Content.ReadAsAsync<IEnumerable<ProductCategory>>().Result;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("ProductCategory", productcategory).Result;
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProductCategory> dataList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ProductCategory").Result;
            dataList = response.Content.ReadAsAsync<IEnumerable<ProductCategory>>().Result;

            //var dataList = await _context.productCategory.GetAllAsync();

            //var dataList = _dbContext.productCategories.Select(x => new ProductCategory
            //{
            //    Id = x.Id,
            //    CategoryName = x.CategoryName,
            //}).ToList();

            return Json(new { data = dataList });
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(ProductCategory productcategory)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("ProductCategory", productcategory).Result;
            }
            return Json(productcategory);
        }


        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ProductCategory/" + id.ToString()).Result;
            var data = response.Content.ReadAsAsync<ProductCategory>().Result;
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int id, ProductCategory productcategory)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //ProductCategory? data = await _context.productCategory.GetByIdAsync(id);
                    //data.CategoryName = productcategory.CategoryName;
                    //await _context.productCategory.UpdateAsync(id, data);
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("ProductCategory/" + productcategory.Id, productcategory).Result;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return Json(productcategory);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("ProductCategory/" + id.ToString()).Result;
            return Json(id);
        }

        [HttpGet]
        public async Task<IActionResult> DetailCategory(int id)
        {

            var data = await _context.productCategory.GetByIdAsync(id);
            if (data == null)
            {
                return Json(NotFound());
            }
            return Json(data);
        }

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var data = await _context.productCategory.GetByIdAsync(id);
        //    if (data == null)
        //    {
        //        return View(NotFound());
        //    }
        //    return View(data);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, ProductCategory category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var data = await _context.productCategory.GetByIdAsync(id);
        //        if (data == null) { return View(NotFound()); }
        //        data.CategoryName = category.CategoryName;
        //        await _context.productCategory.UpdateAsync(id, data);

        //    }
        //    return RedirectToAction("Index");
        //}
        //public async Task<IActionResult> Details(int id)
        //{
        //    try
        //    {
        //        var data = await _context.productCategory.GetByIdAsync(id);
        //        if (data == null)
        //        {
        //            throw new Exception("Invalid Ref Id. Plz Check");
        //        }
        //        return View(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        //error log should be added
        //    }
        //    return RedirectToAction("Index");
        //}
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _context.productCategory.GetByIdAsync(id);
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _context.productCategory.GetByIdAsync(id);
            if (data == null)
            {
                return View();
            }
            await _context.productCategory.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
