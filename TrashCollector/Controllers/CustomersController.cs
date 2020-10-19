﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
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
            var customersOnList = _context.Customers.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            return View();
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customerOnList = _context.Customers.SingleOrDefault(c => c.Id == id);
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
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    customer.IdentityUserId = userId;
                    _context.Add(customer);

                }
                else
                {
                    var customerInDB = _context.Customers.Single(m => m.Id == customer.Id);
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
            var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
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
        public ActionResult SuspendService(int id)
        {
            var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendService(int id, Customer customer)
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
        public bool CompareDates (DateTime startDate, DateTime endDate)
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
                else if (suspendStart >=0 && suspendEnd <= 0)
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
            if (isSuspended == true)
            {
                //remove this from route
            }
        }


    }
}
