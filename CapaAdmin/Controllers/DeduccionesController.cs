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
            using (FENIX_NOMINAEntities db= new FENIX_NOMINAEntities()) {

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
    }
}