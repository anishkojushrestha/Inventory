using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Inventory_Project.Data;
using Inventory_Project.Models;
using Inventory_Project.ModelViews;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Project.Controllers
{
    public class UploadFController : Controller
    {
        

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext _db;

        public UploadFController(IWebHostEnvironment _webHostEnvironment,ApplicationDbContext _db)
        {
            this._db = _db;
            webHostEnvironment = _webHostEnvironment;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            IEnumerable<Customer> data = _db.customers;


            return View(data);
        }

        [HttpPost]
        public IActionResult FileUpload(CustomerMV customerMV)
        {
            string fileName, filePaths;
            Customer cm = new Customer();
            FileUpload(customerMV.formFile, out fileName, out filePaths);
            cm.FileName = fileName;
            cm.FilePath = filePaths;
            _db.customers.Add(cm);
            _db.SaveChanges();
            return Json(new { status = "success", fileName = cm.FileName, fileSize = customerMV.formFile.Length });
        }

        public void FileUpload(IFormFile? formfile,out string fileName,out string filePaths)
        {
            DateTime today = DateTime.Now;
            int year = today.Year;
            int month = today.Month;

            string newpath = "upload/" + year.ToString() + "/" + month.ToString();
            string folderpath = Path.Combine(webHostEnvironment.WebRootPath, newpath);
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

           var filepath = Path.Combine(folderpath,formfile.FileName);
           using var stream = new FileStream(filepath, FileMode.Create);
           formfile.CopyTo(stream);
           fileName = formfile.FileName;
           filePaths = folderpath;
        }



    }
}
