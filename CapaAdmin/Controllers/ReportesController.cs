using CapaAdmin.Models.ViewModel;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaAdmin.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes


        public ActionResult Index(string nombre = "")
        {
            ViewBag.nombre = nombre;
            return View();
        }




        public ActionResult Reportes()
        {
            List<PersonaViewModel> lst = new List<PersonaViewModel>();
            lst.Add(new PersonaViewModel() { Nombre = "Luis Alejandro", Puesto = "Cajero", SalarioxMes = 12000 });
            lst.Add(new PersonaViewModel() { Nombre = "Ana Maria", Puesto = "Auxiliar", SalarioxMes = 22000 });
            lst.Add(new PersonaViewModel() { Nombre = "Alex Fernandez", Puesto = "Seguridad", SalarioxMes = 22420 });
            lst.Add(new PersonaViewModel() { Nombre = "Rosa Milano", Puesto = "Limpieza", SalarioxMes = 11000 });
            lst.Add(new PersonaViewModel() { Nombre = "Roberto Botnen", Puesto = "Encargado", SalarioxMes = 32100 });
            lst.Add(new PersonaViewModel() { Nombre = "Cabrito Luna", Puesto = "Administrador", SalarioxMes = 55010 });
            lst.Add(new PersonaViewModel() { Nombre = "Boyuner Gusman", Puesto = "Asistente", SalarioxMes = 25000 });
            lst.Add(new PersonaViewModel() { Nombre = "Rosadoes Rita", Puesto = "Cajero", SalarioxMes = 13200 });
            lst.Add(new PersonaViewModel() { Nombre = "Mariano Lumbar", Puesto = "Cajero sustituto", SalarioxMes = 8000 });
            lst.Add(new PersonaViewModel() { Nombre = "Adriana Carolina", Puesto = "Auxiliar", SalarioxMes = 22300 });
            lst.Add(new PersonaViewModel() { Nombre = "Alejandro Enrique", Puesto = "Seguridad", SalarioxMes = 22420 });
            lst.Add(new PersonaViewModel() { Nombre = "Carlos Gomez", Puesto = "Limpieza", SalarioxMes = 2410 });
            lst.Add(new PersonaViewModel() { Nombre = "Daniela Marcela", Puesto = "Encargado", SalarioxMes = 32100 });
            lst.Add(new PersonaViewModel() { Nombre = "Estewil Quesada", Puesto = "Administrador", SalarioxMes = 60010 });
            lst.Add(new PersonaViewModel() { Nombre = "Gloria Nieto", Puesto = "Asistente", SalarioxMes = 38900 });
            lst.Add(new PersonaViewModel() { Nombre = "Diana Diaz Beltran", Puesto = "Cajero", SalarioxMes = 13200 });


            return View(lst);
        }

        public ActionResult Print()
        {

            return new ActionAsPdf("Reportes")
            { FileName = "Test.pdf" };
        }




    }
}