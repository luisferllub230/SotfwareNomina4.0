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
    public class DeduccionesController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: Deducciones
        public ActionResult Index()
        {
            return View(db.TP_DEDUCCIONES.ToList());
        }

        // GET: Deducciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TP_DEDUCCIONES tP_DEDUCCIONES = db.TP_DEDUCCIONES.Find(id);
            if (tP_DEDUCCIONES == null)
            {
                return HttpNotFound();
            }
            return View(tP_DEDUCCIONES);
        }

        // GET: Deducciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deducciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TPDEDU,NOMBRE,DEPENDE_SALARIO,ESTADO")] TP_DEDUCCIONES tP_DEDUCCIONES)
        {
            if (ModelState.IsValid)
            {
                db.TP_DEDUCCIONES.Add(tP_DEDUCCIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tP_DEDUCCIONES);
        }

        // GET: Deducciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TP_DEDUCCIONES tP_DEDUCCIONES = db.TP_DEDUCCIONES.Find(id);
            if (tP_DEDUCCIONES == null)
            {
                return HttpNotFound();
            }
            return View(tP_DEDUCCIONES);
        }

        // POST: Deducciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TPDEDU,NOMBRE,DEPENDE_SALARIO,ESTADO")] TP_DEDUCCIONES tP_DEDUCCIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tP_DEDUCCIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tP_DEDUCCIONES);
        }

        // GET: Deducciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TP_DEDUCCIONES tP_DEDUCCIONES = db.TP_DEDUCCIONES.Find(id);
            if (tP_DEDUCCIONES == null)
            {
                return HttpNotFound();
            }
            return View(tP_DEDUCCIONES);
        }

        // POST: Deducciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TP_DEDUCCIONES tP_DEDUCCIONES = db.TP_DEDUCCIONES.Find(id);
            db.TP_DEDUCCIONES.Remove(tP_DEDUCCIONES);
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
