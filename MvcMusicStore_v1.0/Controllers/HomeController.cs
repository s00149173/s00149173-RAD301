﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore_v1._0.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private MvcMusicStoreEntities db = new MvcMusicStoreEntities();
        private static int Date = 1;
        private static int Value = 1;

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult Index(string searchString)
        {
            if (searchString == null)
            {
                var orders = db.Orders;
                return View(orders);
            }
            var searchResult = db.Orders.Where(o => o.FirstName.Contains(searchString) || o.LastName.Contains(searchString));
            return View(searchResult);
        }

        public ActionResult SortByDate()
        {
            var sortedOrdersByData= db.Orders.OrderBy(o => o.OrderDate);
            if (Date % 2 == 0)
            {
                sortedOrdersByData = db.Orders.OrderByDescending(o => o.OrderDate);
             }
            Date++;
            return View("Index", sortedOrdersByData);
        }

        /*public ActionResult SortByFirstName()
        {
            var sortedOrdersByFirstName = db.Orders.OrderBy(o => o.FirstName);
            return View("Index", sortedOrdersByFirstName);
        }

        public ActionResult SortByLastName()
        {
            var sortedOrdersByLastName = db.Orders.OrderBy(o => o.LastName);
            return View("Index", sortedOrdersByLastName);
        }*/

        public ActionResult SortByValue()
        {
            var sortedOrdersByValue = db.Orders.OrderBy(o => o.Total);
            if (Value % 2 == 0)
            {
                sortedOrdersByValue = db.Orders.OrderByDescending(o => o.Total);
            }
            Value++;
            return View("Index", sortedOrdersByValue);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

