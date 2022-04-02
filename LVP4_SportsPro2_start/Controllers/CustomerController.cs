using LVP4_SportsPro2_start.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LVP4_SportsPro2_start.Controllers
{
    /****************************************************
    * 
    * Update the private helper method below 
    * 
    ****************************************************/
    public class CustomerController : Controller
    {
        // Notice the Unit of Work 
        private SportsProUnit data { get; set; }

        // Do not change the constructor; it is correct below
        public CustomerController(SportsProContext ctx)
        {
            data = new SportsProUnit(ctx);
        }

        [Route("[controller]s")]
        // List() method has been updated to reference the unit of work 
        public IActionResult List()
        {
            var customers = data.Customers.List(new QueryOptions<Customer>
            {
                OrderBy = c => c.LastName
            });
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            ViewBag.Countries = GetCountryList();

            return View("AddEdit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            ViewBag.Countries = GetCountryList();

            var customer = data.Customers.Get(id);
            return View("AddEdit", customer);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (customer.CountryID == "XX")
            {
                ModelState.AddModelError(nameof(Customer.CountryID), "Required.");
            }

            if (customer.CustomerID == 0 && TempData["okEmail"] == null)  // only check on new customer - don't check on edit
            {
                string msg = Check.EmailExists(data.Customers, customer.Email);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
            }

            if (ModelState.IsValid)
            {
                if (customer.CustomerID == 0)
                {
                    data.Customers.Insert(customer);
                }
                else
                {
                    data.Customers.Update(customer);
                }
                data.Save();
                return RedirectToAction("List");
            }
            else
            {
                if (customer.CustomerID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";
                }
                return View("AddEdit", customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = data.Customers.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            data.Customers.Delete(customer);
            data.Save();
            return RedirectToAction("List");
        }

        // private helper method called GetCountryList
        /*******************************************************
        *  
        *  Update GetCountryList HERE 
        *  
        ********************************************************/
    }
}