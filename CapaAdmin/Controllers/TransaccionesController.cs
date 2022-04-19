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
    public class TransaccionesController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: Transacciones
        public ActionResult Index()
        {
            return View(db.TRANSACCIONs.ToList());
        }

        // GET: Transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCIONs.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // GET: Transacciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRANS,TIPO_TRANSACCION")] TRANSACCION tRANSACCION)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACCIONs.Add(tRANSACCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRANSACCION);
        }

        // GET: Transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCIONs.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Transacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACCION tRANSACCION = db.TRANSACCIONs.Find(id);
            if (tRANSACCION == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACCION);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANSACCION tRANSACCION = db.TRANSACCIONs.Find(id);
            db.TRANSACCIONs.Remove(tRANSACCION);
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
