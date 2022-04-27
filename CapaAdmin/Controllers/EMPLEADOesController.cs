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
    public class EMPLEADOesController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: EMPLEADOes
        public ActionResult Index()
        {
            var eMPLEADO = db.EMPLEADO.Include(e => e.DEPARTAMENTO).Include(e => e.PUESTO).Include(e => e.TIPO_NOMINA);
            return View(eMPLEADO.ToList());
        }

        // GET: EMPLEADOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTO, "ID_DEPAR", "NOMBRE");
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUES", "NOMBRE");
            ViewBag.ID_NOMINA = new SelectList(db.TIPO_NOMINA, "ID_TI", "Nombre");
            return View();
        }

        // POST: EMPLEADOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMPLE,CEDULA,NOMBRE,SALARIO,ID_DEPARTAMENTO,ID_PUESTO,ID_NOMINA")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADO.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTO, "ID_DEPAR", "NOMBRE", eMPLEADO.ID_DEPARTAMENTO);
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUES", "NOMBRE", eMPLEADO.ID_PUESTO);
            ViewBag.ID_NOMINA = new SelectList(db.TIPO_NOMINA, "ID_TI", "Nombre", eMPLEADO.ID_NOMINA);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTO, "ID_DEPAR", "NOMBRE", eMPLEADO.ID_DEPARTAMENTO);
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUES", "NOMBRE", eMPLEADO.ID_PUESTO);
            ViewBag.ID_NOMINA = new SelectList(db.TIPO_NOMINA, "ID_TI", "Nombre", eMPLEADO.ID_NOMINA);
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMPLE,CEDULA,NOMBRE,SALARIO,ID_DEPARTAMENTO,ID_PUESTO,ID_NOMINA")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DEPARTAMENTO = new SelectList(db.DEPARTAMENTO, "ID_DEPAR", "NOMBRE", eMPLEADO.ID_DEPARTAMENTO);
            ViewBag.ID_PUESTO = new SelectList(db.PUESTO, "ID_PUES", "NOMBRE", eMPLEADO.ID_PUESTO);
            ViewBag.ID_NOMINA = new SelectList(db.TIPO_NOMINA, "ID_TI", "Nombre", eMPLEADO.ID_NOMINA);
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            db.EMPLEADO.Remove(eMPLEADO);
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
