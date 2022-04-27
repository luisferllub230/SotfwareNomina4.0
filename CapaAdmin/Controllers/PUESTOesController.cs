﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapaAdmin.Models;

namespace CapaAdmin.Controllers
{
    public class PUESTOesController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: PUESTOes
        public ActionResult Index()
        {
            return View(db.PUESTO.ToList());
        }

        // GET: PUESTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTO pUESTO = db.PUESTO.Find(id);
            if (pUESTO == null)
            {
                return HttpNotFound();
            }
            return View(pUESTO);
        }

        // GET: PUESTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PUESTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PUES,NOMBRE,NIVEL_RIESGO,NIVEL_MN_SALARIO,NIVEL_MX_SALARIO")] PUESTO pUESTO)
        {
            if (ModelState.IsValid)
            {
                db.PUESTO.Add(pUESTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pUESTO);
        }

        // GET: PUESTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTO pUESTO = db.PUESTO.Find(id);
            if (pUESTO == null)
            {
                return HttpNotFound();
            }
            return View(pUESTO);
        }

        // POST: PUESTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PUES,NOMBRE,NIVEL_RIESGO,NIVEL_MN_SALARIO,NIVEL_MX_SALARIO")] PUESTO pUESTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUESTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pUESTO);
        }

        // GET: PUESTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUESTO pUESTO = db.PUESTO.Find(id);
            if (pUESTO == null)
            {
                return HttpNotFound();
            }
            return View(pUESTO);
        }

        // POST: PUESTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PUESTO pUESTO = db.PUESTO.Find(id);
            db.PUESTO.Remove(pUESTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
