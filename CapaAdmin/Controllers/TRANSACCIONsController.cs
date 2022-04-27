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
    public class TRANSACCIONsController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: TRANSACCIONs
        public ActionResult Index()
        {
            return View(db.TRANSACCION.ToList());
        }

        // GET: TRANSACCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCION.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // GET: TRANSACCIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRANSACCIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRANS,TIPO_TRANSACCION")] TRANSACCION tRANSACCION)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACCION.Add(tRANSACCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRANSACCION);
        }

        // GET: TRANSACCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCION.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // POST: TRANSACCIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TRANS,TIPO_TRANSACCION")] TRANSACCION tRANSACCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANSACCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRANSACCION);
        }

        // GET: TRANSACCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCION.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // POST: TRANSACCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANSACCION tRANSACCION = db.TRANSACCION.Find(id);
            db.TRANSACCION.Remove(tRANSACCION);
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
