using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ornekWeb.Models;
using ornekWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace ornekWeb.Controllers
{
    [Authorize]
    public class FirmController : Controller
    {
        private readonly IEntityData<Firm> firmData;

        public FirmController(IEntityData<Firm> firmData)
        {
            this.firmData = firmData;
        }
        // GET: FirmController


        public ActionResult Index()
        {
            return View(firmData.GetAll());
        }

        // GET: FirmController/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            Firm firm = firmData.GetById(id);
            if (firm != null)
                return View(firmData.GetById(id));
            else
                return NotFound();
        }

        // GET: FirmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FirmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Firm firm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    firmData.Insert(firm);
                    firmData.Commit();

                    return RedirectToAction(nameof(Index));
                }

                return View(firm);
            }
            catch
            {
                return View();
            }
        }

        // GET: FirmController/Edit/5
        public ActionResult Edit(int id)
        {
            Firm firm = firmData.GetById(id);
            if (firm != null)
                return View(firm);
            else
                return NotFound();
        }

        // POST: FirmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Firm firm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    firmData.Update(firm);
                    firmData.Commit();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(firm);
            }
            catch
            {
                return View();
            }
        }

        // GET: FirmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FirmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                firmData.Delete(id);
                firmData.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
