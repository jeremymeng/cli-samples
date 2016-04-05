using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloMvc.Models;
using HelloMvc.Validators;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet("/Customer/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("/Customer/")]
        public ActionResult Index(Customer model)
        {
            CustomerValidator validator = new CustomerValidator();
            var result = validator.Validate(model);
            if (result.IsValid)
            {
                ViewBag.Name = "Valid: " + model.Name;
                ViewBag.Email = "Valid: " + model.Email;
            }
            else
            {
                foreach (var failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }
            return View(model);
        }
    }
}
