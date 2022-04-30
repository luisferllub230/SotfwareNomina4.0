using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Capa_de_presentacion.Models;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
namespace Capa_de_presentacion.Controllers
{
    public class AccesoController : Controller
    {


        static string cadena = "Data Source=LUIS;Initial Catalog=FENIX_NOMINA;Integrated Security=true";
        // GET: Acceso
        public ActionResult Login()
        { 
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Registrar(Usuario oUsuario)
        {
            bool registrado;
            string mensaje;
            
            //validar ambas contraseñas
            if (oUsuario.CONTRASEÑA == oUsuario.Confir_Clave)
            {
                oUsuario.CONTRASEÑA = ConvertirSha256(oUsuario.CONTRASEÑA);
            }
            else
            {
                ViewData["Mensaje"] = "LAS CONTRASEÑAS NO COINCIDEN";
                return View();

            }
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("RegistroUser", cn);
                cmd.Parameters.AddWithValue("Nombre", oUsuario.NOMBRES);
                cmd.Parameters.AddWithValue("Correo", oUsuario.USUARIO);
                cmd.Parameters.AddWithValue("Passw", oUsuario.CONTRASEÑA);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,70).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            ViewData["Mensaje"] = mensaje; 


            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }




        }
        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {

            oUsuario.CONTRASEÑA = ConvertirSha256(oUsuario.CONTRASEÑA);

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("ValidarUser", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.USUARIO);
                cmd.Parameters.AddWithValue("Pass", oUsuario.CONTRASEÑA);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteScalar();

                oUsuario.ID_USER = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                
        }
            if (oUsuario.ID_USER != 0)
            {
                Session["usuario"] = oUsuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "USUARIO NO ENCONTRADO";
                return View();


            }



        }

        public static string ConvertirSha256(string texto)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
               
        }

    }
}