using System;
using System.Collections.Generic;
using System.Linq;
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
        // GET: EmployeesController
        public ActionResult Index()
        {
            var employeesOnList = _context.Employees.ToList();
            return View(employeesOnList);
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
        public ActionResult PickUps()
        {
            var employeesOnList = _context.Employees.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Customers.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();

            var customersOnList = _context.Customers.Where(c => c.ZipCode == employee.ZipCode);            
            return View(customersOnList);
        }
        public bool CompareDates(DateTime startDate, DateTime endDate)
        {
            var suspendStartDate = _context.Customers.Select(d => d.SuspensionStartDate).FirstOrDefault();
            var suspendEndDate = _context.Customers.Select(d => d.SuspensionEndDate).FirstOrDefault();
            var currentDate = DateTime.Now;
            if (suspendStartDate != null)
            {
                int suspendStart = DateTime.Compare(suspendStartDate, currentDate);
                int suspendEnd = DateTime.Compare(suspendEndDate, currentDate);
                if (suspendStart < 0)
                {
                    return false;
                }
                else if (suspendStart >= 0 && suspendEnd >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void TakeOffRoute(bool isSuspended)
        {
            var pickUpDay = _context.Customers.Select(d => d.PickUpDay).FirstOrDefault();
            DateTime today = DateTime.Now;

            if (pickUpDay != today.DayOfWeek.ToString())
            {
                //remove this from route
                //create list of 
            }
        }




    }
}
