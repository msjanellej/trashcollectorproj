using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
// using AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Employee")]

    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            var employeesOnList = _context.Employees.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var customersOnRoute = _context.Customers.Where(c => c.ZipCode == employee.ZipCode).ToList();  
            DateTime today = DateTime.Now;
            List<Customer> todaysPickUps = new List<Customer>();
            foreach (var customer in customersOnRoute)
            {
                if (customer.PickUpDay == today.DayOfWeek.ToString())
                {
                    todaysPickUps.Add(customer);    
                }
            }
            
            return View(todaysPickUps);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.Where(c => c.Id == id).SingleOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                _context.Update(employee);
                _context.SaveChanges();

                return RedirectToAction("Index", "Employees");
                
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PickUps(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult PickUps(string dayOfPickUp)
        {

            var employeesOnList = _context.Employees.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var customersOnRoute = _context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.PickUpDay == dayOfPickUp).ToList();
            return View("Index", customersOnRoute);
        }
        public ActionResult ConfirmPickUp(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ConfirmPickUp(string dayOfPickUp)
        {

            var employeesOnList = _context.Employees.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var customersOnRoute = _context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.PickUpDay == dayOfPickUp).ToList();
            return View("Index", customersOnRoute);
        }





    }
}
