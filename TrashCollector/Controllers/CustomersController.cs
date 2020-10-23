﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
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
    [Authorize(Roles = "Customer")]


    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        static readonly HttpClient httpClient = new HttpClient();


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
            //if customer is null then redirect to the create page
            if (customer == null)
            {
                return RedirectToAction("Create", "Customers");
            }
            return View(customer);
        }
        // GET: CustomersController/Details/5
        public ActionResult Details() //Do I need this??? 
        {
            var customersOnList = _context.Customers.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            return View(customer);
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
                GetCoordinates(customer.StreetAddress, customer.City, customer.State);
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Details", "Customers");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customersOnList = _context.Customers.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
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
                GetCoordinates(customer.StreetAddress, customer.City, customer.State);
                _context.Update(customer);
                _context.SaveChanges();

                return RedirectToAction("Details", "Customers");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SuspendService(int id)
        {
            var customersOnList = _context.Customers.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
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
        static async Task GetCoordinates(string streetAddress, string city, string state)
        {
            try
            {

                var URL = $"https://maps.googleapis.com/maps/api/geocode/json?address={streetAddress}+{city}+{state}&key={APIkeys.GOOGLE_API_KEY}";
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return;
            }
            catch
            {
                return;
            }
        }



    }
}
