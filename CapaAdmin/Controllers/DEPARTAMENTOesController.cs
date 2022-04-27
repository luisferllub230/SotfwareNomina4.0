using System;
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
    public class DEPARTAMENTOesController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: DEPARTAMENTOes
        public ActionResult Index()
        {
            var dEPARTAMENTO = db.DEPARTAMENTO.Include(d => d.EMPLEADO1);
            return View(dEPARTAMENTO.ToList());
        }

        // GET: DEPARTAMENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTO.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Create
        public ActionResult Create()
        {
            ViewBag.RESPONSABLE_AREA = new SelectList(db.EMPLEADO, "ID_EMPLE", "CEDULA");
            return View();
        }

        // POST: DEPARTAMENTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DEPAR,NOMBRE,UBICACION,RESPONSABLE_AREA")] DEPARTAMENTO dEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTAMENTO.Add(dEPARTAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RESPONSABLE_AREA = new SelectList(db.EMPLEADO, "ID_EMPLE", "CEDULA", dEPARTAMENTO.RESPONSABLE_AREA);
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTO.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.RESPONSABLE_AREA = new SelectList(db.EMPLEADO, "ID_EMPLE", "CEDULA", dEPARTAMENTO.RESPONSABLE_AREA);
            return View(dEPARTAMENTO);
        }

        // POST: DEPARTAMENTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DEPAR,NOMBRE,UBICACION,RESPONSABLE_AREA")] DEPARTAMENTO dEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RESPONSABLE_AREA = new SelectList(db.EMPLEADO, "ID_EMPLE", "CEDULA", dEPARTAMENTO.RESPONSABLE_AREA);
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTO.Find(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // POST: DEPARTAMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPARTAMENTO dEPARTAMENTO = db.DEPARTAMENTO.Find(id);
            db.DEPARTAMENTO.Remove(dEPARTAMENTO);
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
