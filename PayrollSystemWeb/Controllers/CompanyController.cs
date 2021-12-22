using Microsoft.AspNetCore.Mvc;
using PayrollSystem;
using PayrollWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PayrollWeb.Controllers
{

    public class CompanyController : Controller
    {
        private IPaySystemService svc;
        public CompanyController(IPaySystemService svc)
        {
            this.svc = svc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var comp = svc.GetCompanyDetail(id);
            var model = new CompanyDetailViewModel()
            {
                Id = id,
                TaxId = comp.taxid,
                StreetAddress = comp.address,
                Name = comp.name
            };

            return View(model);
        }

        public IActionResult SaveDetail(CompanyDetailViewModel model) //onPost
        {
            if (ModelState.IsValid)
            {
                svc.SaveCompanyDetail(model.Id, model.TaxId, model.Name, model.StreetAddress);
                return View("Index");
            }
            else
                return View("Detail", model);
        }
    }
}
