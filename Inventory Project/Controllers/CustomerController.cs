using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.ModelViews;
using Inventory_Project.Repo.IRepo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using static NuGet.Packaging.PackagingConstants;
using System.Web;


namespace Inventory_Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly ApplicationDbContext _db;
        public CustomerController(IUnitOfWork _context, IWebHostEnvironment webHostEnvironment, ApplicationDbContext db)
        {
            this._context = _context;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Customer> data ;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customer").Result;
            data = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return View(data);
        }

        public IActionResult Create()
        {
            IEnumerable<Image> data = _db.images;
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Customer", customer).Result;
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UploadFile(CustomerVM vm)
        {
            var image = new Image();
            image.img =
            UploadFile(vm.formFile);
            _db.images.Add(image);
            _db.SaveChanges();
            return View();
        }
        private string UploadFile(IFormFile? file)
        {
            string uniqueFileName = "";
            string newpath = "upload/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MMMM");
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, newpath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(folderPath, uniqueFileName);
            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
            }


            return uniqueFileName;
        }

        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customer/"+id.ToString()).Result;

            if (response == null)
            {
                return View(NotFound());
            }
            return View(response.Content.ReadAsAsync<Customer>().Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Customer/"+customer.Id, customer).Result;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            
            return View(customer);
        }


        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Customer/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}
