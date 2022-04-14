using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAdmin.Models;
using CapaAdmin.Models.ViewModel;

namespace CapaAdmin.Controllers
{
    public class DeduccionesController : Controller
    {
        

        // GET: Deducciones
        public ActionResult Deducciones()
        {
            List<DataGestionDeducciones> lst;
            using (FENIX_NOMINAEntities db = new FENIX_NOMINAEntities()) {

                lst = (from d in db.TP_DEDUCCIONES
                       select new DataGestionDeducciones
                       {
                           ID_TPDEDU = d.ID_TPDEDU,
                           NOMBRE = d.NOMBRE,
                           DEPENDE_SALARIO = d.DEPENDE_SALARIO,
                           ESTADO = d.ESTADO,
                       }).ToList();
            }

            return View(lst);
        }


        public ActionResult CrearDeduccion() {

            return View();
        }


        [HttpPost]
        public ActionResult CrearDeduccion(DataGestionDeduccionesLlenar model) {

            try
            {
                if (ModelState.IsValid)
                {
                    using (FENIX_NOMINAEntities db = new FENIX_NOMINAEntities())
                    {
                        var oDEDUCCIONES = new TP_DEDUCCIONES();
                        oDEDUCCIONES.NOMBRE = model.NOMBRE;
                        oDEDUCCIONES.DEPENDE_SALARIO = model.DEPENDE_SALARIO;
                        oDEDUCCIONES.ESTADO = model.ESTADO;

                        db.TP_DEDUCCIONES.Add(oDEDUCCIONES);
                        db.SaveChanges();
                    }
                    return  Redirect("/Deducciones"); 
                }

                return View(model);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}