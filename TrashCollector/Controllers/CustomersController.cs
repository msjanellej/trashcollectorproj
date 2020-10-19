using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            var customersOnList = _context.Customer.ToList();
            return View(customersOnList);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customerOnList = _context.Customer.SingleOrDefault(c => c.Id == id);
            return View(customerOnList);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            try
            {
                if (customer.Id == 0)
                {
                    _context.Customer.Add(customer);
                }
                else
                {
                    var customerInDB = _context.Customer.Single(m => m.Id == customer.Id);
                    customerInDB.FirstName = customer.FirstName;
                    customerInDB.LastName = customer.LastName;
                    customerInDB.StreetAddress = customer.StreetAddress;
                    customerInDB.City = customer.City;
                    customerInDB.State = customer.State;
                    customerInDB.ZipCode = customer.ZipCode;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.Where(c => c.Id == id).SingleOrDefault();
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                
                _context.Update(customer);
                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
