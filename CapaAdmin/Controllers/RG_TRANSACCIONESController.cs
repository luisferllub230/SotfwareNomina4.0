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
    public class RG_TRANSACCIONESController : Controller
    {
        private FENIX_NOMINAEntities db = new FENIX_NOMINAEntities();

        // GET: RG_TRANSACCIONES
        public ActionResult Index()
        {
            var rG_TRANSACCIONES = db.RG_TRANSACCIONES.Include(r => r.EMPLEADO).Include(r => r.TP_DEDUCCIONES).Include(r => r.TIPO_INGRESO).Include(r => r.TRANSACCION);
            return View(rG_TRANSACCIONES.ToList());
        }

        // GET: RG_TRANSACCIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RG_TRANSACCIONES rG_TRANSACCIONES = db.RG_TRANSACCIONES.Find(id);
            if (rG_TRANSACCIONES == null)
            {
                return HttpNotFound();
            }
            return View(rG_TRANSACCIONES);
        }

        // GET: RG_TRANSACCIONES/Create
        public ActionResult Create()
        {
            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLE", "CEDULA");
            ViewBag.ID_DEDUCCION = new SelectList(db.TP_DEDUCCIONES, "ID_TPDEDU", "NOMBRE");
            ViewBag.ID_INGRESO = new SelectList(db.TIPO_INGRESO, "ID_INGR", "NOMBRE");
            ViewBag.ID_TIPO_TRANSACCION = new SelectList(db.TRANSACCION, "ID_TRANS", "TIPO_TRANSACCION");
            return View();
        }

        // POST: RG_TRANSACCIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RGTRANS,ID_EMPLEADO,ID_INGRESO,ID_DEDUCCION,ID_TIPO_TRANSACCION,FECHA,MONTO,ESTADO")] RG_TRANSACCIONES rG_TRANSACCIONES)
        {
            if (ModelState.IsValid)
            {
                db.RG_TRANSACCIONES.Add(rG_TRANSACCIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLE", "CEDULA", rG_TRANSACCIONES.ID_EMPLEADO);
            ViewBag.ID_DEDUCCION = new SelectList(db.TP_DEDUCCIONES, "ID_TPDEDU", "NOMBRE", rG_TRANSACCIONES.ID_DEDUCCION);
            ViewBag.ID_INGRESO = new SelectList(db.TIPO_INGRESO, "ID_INGR", "NOMBRE", rG_TRANSACCIONES.ID_INGRESO);
            ViewBag.ID_TIPO_TRANSACCION = new SelectList(db.TRANSACCION, "ID_TRANS", "TIPO_TRANSACCION", rG_TRANSACCIONES.ID_TIPO_TRANSACCION);
            return View(rG_TRANSACCIONES);
        }

        // GET: RG_TRANSACCIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RG_TRANSACCIONES rG_TRANSACCIONES = db.RG_TRANSACCIONES.Find(id);
            if (rG_TRANSACCIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLE", "CEDULA", rG_TRANSACCIONES.ID_EMPLEADO);
            ViewBag.ID_DEDUCCION = new SelectList(db.TP_DEDUCCIONES, "ID_TPDEDU", "NOMBRE", rG_TRANSACCIONES.ID_DEDUCCION);
            ViewBag.ID_INGRESO = new SelectList(db.TIPO_INGRESO, "ID_INGR", "NOMBRE", rG_TRANSACCIONES.ID_INGRESO);
            ViewBag.ID_TIPO_TRANSACCION = new SelectList(db.TRANSACCION, "ID_TRANS", "TIPO_TRANSACCION", rG_TRANSACCIONES.ID_TIPO_TRANSACCION);
            return View(rG_TRANSACCIONES);
        }

        // POST: RG_TRANSACCIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RGTRANS,ID_EMPLEADO,ID_INGRESO,ID_DEDUCCION,ID_TIPO_TRANSACCION,FECHA,MONTO,ESTADO")] RG_TRANSACCIONES rG_TRANSACCIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rG_TRANSACCIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EMPLEADO = new SelectList(db.EMPLEADO, "ID_EMPLE", "CEDULA", rG_TRANSACCIONES.ID_EMPLEADO);
            ViewBag.ID_DEDUCCION = new SelectList(db.TP_DEDUCCIONES, "ID_TPDEDU", "NOMBRE", rG_TRANSACCIONES.ID_DEDUCCION);
            ViewBag.ID_INGRESO = new SelectList(db.TIPO_INGRESO, "ID_INGR", "NOMBRE", rG_TRANSACCIONES.ID_INGRESO);
            ViewBag.ID_TIPO_TRANSACCION = new SelectList(db.TRANSACCION, "ID_TRANS", "TIPO_TRANSACCION", rG_TRANSACCIONES.ID_TIPO_TRANSACCION);
            return View(rG_TRANSACCIONES);
        }

        // GET: RG_TRANSACCIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RG_TRANSACCIONES rG_TRANSACCIONES = db.RG_TRANSACCIONES.Find(id);
            if (rG_TRANSACCIONES == null)
            {
                return HttpNotFound();
            }
            return View(rG_TRANSACCIONES);
        }

        // POST: RG_TRANSACCIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RG_TRANSACCIONES rG_TRANSACCIONES = db.RG_TRANSACCIONES.Find(id);
            db.RG_TRANSACCIONES.Remove(rG_TRANSACCIONES);
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
