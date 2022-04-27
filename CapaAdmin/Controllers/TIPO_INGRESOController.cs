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
    public class TIPO_INGRESOController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: TIPO_INGRESO
        public ActionResult Index()
        {
            return View(db.TIPO_INGRESO.ToList());
        }

        // GET: TIPO_INGRESO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_INGRESO tIPO_INGRESO = db.TIPO_INGRESO.Find(id);
            if (tIPO_INGRESO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_INGRESO);
        }

        // GET: TIPO_INGRESO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_INGRESO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_INGR,NOMBRE,DEPENDE_SALARIO,ESTADO")] TIPO_INGRESO tIPO_INGRESO)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_INGRESO.Add(tIPO_INGRESO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_INGRESO);
        }

        // GET: TIPO_INGRESO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_INGRESO tIPO_INGRESO = db.TIPO_INGRESO.Find(id);
            if (tIPO_INGRESO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_INGRESO);
        }

        // POST: TIPO_INGRESO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_INGR,NOMBRE,DEPENDE_SALARIO,ESTADO")] TIPO_INGRESO tIPO_INGRESO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_INGRESO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_INGRESO);
        }

        // GET: TIPO_INGRESO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_INGRESO tIPO_INGRESO = db.TIPO_INGRESO.Find(id);
            if (tIPO_INGRESO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_INGRESO);
        }

        // POST: TIPO_INGRESO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_INGRESO tIPO_INGRESO = db.TIPO_INGRESO.Find(id);
            db.TIPO_INGRESO.Remove(tIPO_INGRESO);
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
