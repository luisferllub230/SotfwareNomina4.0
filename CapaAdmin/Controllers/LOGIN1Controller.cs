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
    public class LOGIN1Controller : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: LOGIN1
        public ActionResult Index()
        {
            return View(db.LOGIN1.ToList());
        }

        // GET: LOGIN1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN1 lOGIN1 = db.LOGIN1.Find(id);
            if (lOGIN1 == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN1);
        }

        // GET: LOGIN1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOGIN1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USER,NOMBRES,USUARIO,CONTRASEÑA,TIPO_USUARIO")] LOGIN1 lOGIN1)
        {
            if (ModelState.IsValid)
            {
                db.LOGIN1.Add(lOGIN1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOGIN1);
        }

        // GET: LOGIN1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN1 lOGIN1 = db.LOGIN1.Find(id);
            if (lOGIN1 == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN1);
        }

        // POST: LOGIN1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USER,NOMBRES,USUARIO,CONTRASEÑA,TIPO_USUARIO")] LOGIN1 lOGIN1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOGIN1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOGIN1);
        }

        // GET: LOGIN1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN1 lOGIN1 = db.LOGIN1.Find(id);
            if (lOGIN1 == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN1);
        }

        // POST: LOGIN1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOGIN1 lOGIN1 = db.LOGIN1.Find(id);
            db.LOGIN1.Remove(lOGIN1);
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
