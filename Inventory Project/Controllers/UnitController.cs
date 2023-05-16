using Inventory_Project.Migrations;
using Inventory_Project.Models;
using Inventory_Project.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;

namespace Inventory_Project.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitOfWork _context;
        public UnitController(IUnitOfWork _context)
        {
            this._context = _context;
        }
        public async Task<IActionResult> Index()
        {
            //IEnumerable<Unit> data;
            //HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Unit").Result;
            //data = response.Content.ReadAsAsync<IEnumerable<Unit>>().Result;
            //return View(data);
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Unit", unit).Result;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Unit/" + id.ToString()).Result;

            if (response == null)
            {
                return View(NotFound());
            }
            return View(response.Content.ReadAsAsync<Unit>().Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Unit unit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Unit/" + unit.Id, unit).Result;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(unit);
        }


        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Customer/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

        //ajax 

        public async Task<IActionResult> GetAll()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Unit").Result;
            IEnumerable<Unit> dataList = response.Content.ReadAsAsync<IEnumerable<Unit>>().Result;
            return Json(new { data = dataList });
        }



        [HttpPost]
        public async Task<IActionResult> AddUnit(Unit unit)
        {

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Unit", unit).Result;
            }

            return Json(unit);
        }




        [HttpGet]
        public async Task<IActionResult> EditUnit(int id)
        {

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Unit/" + id.ToString()).Result;

            if (response == null)
            {
                return View(NotFound());
            }
            var data = response.Content.ReadAsAsync<Unit>().Result;
            return Json(data);
        }
        [HttpPost]
        public async Task<IActionResult> EditUnit(int id, Unit unit)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Unit/" + unit.Id, unit).Result;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return Json(unit);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Unit/" + id.ToString()).Result;
            return Json(id);
        }


    }
}
