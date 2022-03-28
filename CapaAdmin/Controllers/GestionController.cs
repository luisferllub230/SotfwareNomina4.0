using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaAdmin.Controllers
{
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult GestionEmpleados()
        {
            return View();
        }

        
        public ActionResult GestionDepartamentos()
        {
            return View();
        }

        public ActionResult GestionTPIngreso()
        {
            return View();
        }

        public ActionResult GestionDeduccion()
        {
            return View();
        }
    }
}