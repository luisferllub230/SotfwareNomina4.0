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
    public class SOLICITUDsController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: SOLICITUDs
        public ActionResult Index()
        {
            return View(db.SOLICITUD.ToList());
        }

        // GET: SOLICITUDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD sOLICITUD = db.SOLICITUD.Find(id);
            if (sOLICITUD == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUD);
        }

        // GET: SOLICITUDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SOLICITUDs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NOTI,NOMBRE,APELLIDO,TITULO,MENSAJE")] SOLICITUD sOLICITUD)
        {
            if (ModelState.IsValid)
            {
                db.SOLICITUD.Add(sOLICITUD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sOLICITUD);
        }

        // GET: SOLICITUDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD sOLICITUD = db.SOLICITUD.Find(id);
            if (sOLICITUD == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUD);
        }

        // POST: SOLICITUDs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NOTI,NOMBRE,APELLIDO,TITULO,MENSAJE")] SOLICITUD sOLICITUD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOLICITUD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sOLICITUD);
        }

        // GET: SOLICITUDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUD sOLICITUD = db.SOLICITUD.Find(id);
            if (sOLICITUD == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUD);
        }

        // POST: SOLICITUDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLICITUD sOLICITUD = db.SOLICITUD.Find(id);
            db.SOLICITUD.Remove(sOLICITUD);
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
