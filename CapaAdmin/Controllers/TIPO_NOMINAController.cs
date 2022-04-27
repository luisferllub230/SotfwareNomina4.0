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
    public class TIPO_NOMINAController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: TIPO_NOMINA
        public ActionResult Index()
        {
            return View(db.TIPO_NOMINA.ToList());
        }

        // GET: TIPO_NOMINA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_NOMINA tIPO_NOMINA = db.TIPO_NOMINA.Find(id);
            if (tIPO_NOMINA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_NOMINA);
        }

        // GET: TIPO_NOMINA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_NOMINA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TI,Nombre")] TIPO_NOMINA tIPO_NOMINA)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_NOMINA.Add(tIPO_NOMINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_NOMINA);
        }

        // GET: TIPO_NOMINA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_NOMINA tIPO_NOMINA = db.TIPO_NOMINA.Find(id);
            if (tIPO_NOMINA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_NOMINA);
        }

        // POST: TIPO_NOMINA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TI,Nombre")] TIPO_NOMINA tIPO_NOMINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_NOMINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_NOMINA);
        }

        // GET: TIPO_NOMINA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_NOMINA tIPO_NOMINA = db.TIPO_NOMINA.Find(id);
            if (tIPO_NOMINA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_NOMINA);
        }

        // POST: TIPO_NOMINA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_NOMINA tIPO_NOMINA = db.TIPO_NOMINA.Find(id);
            db.TIPO_NOMINA.Remove(tIPO_NOMINA);
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
