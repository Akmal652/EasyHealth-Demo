using Microsoft.AspNetCore.Mvc;
using EasyHealth_Demo.DBContexts;
using EasyHealth_Demo.Models;

namespace EasyHealth_Demo.Controllers
{
    public class HospitalController : Controller
    {
        //create an instance of dbcontext
        private readonly ClientContext _dbContext;

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Hospitals.Add(hospital);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Hospital/Create.cshtml");
        }

        [Route("/Create")]
        public IActionResult NewHospitalForm()
        {
            return View("~/Views/Hospital/NewHospitalForm.cshtml");
        }

        [Route("/Delete")]
        public IActionResult Delete()
        {
            return View("~/Views/Hospital/Delete.cshtml");
        }

        [Route("/Edit")]
        public IActionResult Edit()
        {
            return View("~/Views/Hospital/Edit.cshtml");
        }

        [Route("/Details")]
        public IActionResult Details()
        {
            return View("~/Views/Hospital/Details.cshtml");
        }
    }
}
