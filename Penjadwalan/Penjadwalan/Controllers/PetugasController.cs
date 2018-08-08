using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Penjadwalan.Controllers
{
    public class PetugasController : Controller
    {
        // GET: Petugas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Petugas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Petugas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Petugas/Create
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

        // GET: Petugas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Petugas/Edit/5
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

        // GET: Petugas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Petugas/Delete/5
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
