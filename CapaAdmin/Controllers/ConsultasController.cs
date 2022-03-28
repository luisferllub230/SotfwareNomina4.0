using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaAdmin.Controllers
{
    public class ConsultasController : Controller
    {
        public ActionResult ConsultaDepartamento()
        {
            return View();
        }

        public ActionResult ConsultaPuesto()
        {
            return View();
        }
    }
}