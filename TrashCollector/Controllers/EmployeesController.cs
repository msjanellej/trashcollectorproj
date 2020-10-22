using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Claims;
using System.Threading.Tasks;
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
        //GET: EmployeesController
        public ActionResult Index()
        {
            var employeesOnList = _context.Employees.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            var customersOnRoute = _context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.isPickedUp == false).ToList();
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
        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            return View(customer);
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
            var customersOnList = _context.Customers.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.Id ==
            id).SingleOrDefault();
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmPickUp(Customer customer)
        {
            var customerPickedUp = _context.Customers.Single(m => m.Id == customer.Id);
            customerPickedUp.isPickedUp = customer.isPickedUp;

            customerPickedUp.BalanceDue += 10;
            _context.SaveChanges();
            return View("CustomerDetails", customerPickedUp);
        }

    }
}
