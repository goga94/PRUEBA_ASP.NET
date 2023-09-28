using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRUEBA.Models;
using System.Data;
using System.Data.SqlClient;

namespace PRUEBA.Controllers
{
    public class PrincipalController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadenaDB"].ToString();
        
        private static List<Inventario> olista=new List<Inventario>();

        // GET: Principal
        public ActionResult Inicio()
        {
            olista=new List<Inventario>();

            using (SqlConnection oconexion = new SqlConnection(conexion) )
            {
                SqlCommand cmd = new SqlCommand("select * from Inventario", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Inventario nuevoInventario= new Inventario();

                        nuevoInventario.Clave = Convert.ToInt32(dr["Clave"]);
                        nuevoInventario.Nombre = dr["Nombre"].ToString();
                        nuevoInventario.Tipo_de_Producto = dr["Tipo_de_Producto"].ToString();
                        nuevoInventario.Es_Activo = dr["Es_Activo"].ToString();
                    
                        olista.Add(nuevoInventario);
                    
                    }
                }

            }

                return View(olista);
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int? Clave)
        {
            if(Clave==null)
                return RedirectToAction("Inicio", "Principal");

            Inventario oinventario= olista.Where(c=>c.Clave==Clave).FirstOrDefault();

            return View(oinventario);
        }

        [HttpGet]
        public ActionResult Eliminar(int? Clave)
        {
            if (Clave == null)
                return RedirectToAction("Inicio", "Principal");

            Inventario oinventario = olista.Where(c => c.Clave == Clave).FirstOrDefault();

            return View(oinventario);
        }


        [HttpPost]
        public ActionResult Registrar(Inventario oinventario)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("Registrar", oconexion);
                cmd.Parameters.AddWithValue("Nombre", oinventario.Nombre);
                cmd.Parameters.AddWithValue("Tipo_de_Producto", oinventario.Tipo_de_Producto);
                cmd.Parameters.AddWithValue("Es_Activo", oinventario.Es_Activo);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Principal");
        }


        [HttpPost]
        public ActionResult Editar(Inventario oinventario)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("Editar", oconexion);
                cmd.Parameters.AddWithValue("Clave", oinventario.Clave);
                cmd.Parameters.AddWithValue("Nombre", oinventario.Nombre);
                cmd.Parameters.AddWithValue("Tipo_de_Producto", oinventario.Tipo_de_Producto);
                cmd.Parameters.AddWithValue("Es_Activo", oinventario.Es_Activo);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Principal");
        }

        [HttpPost]
        public ActionResult Eliminar(string Clave)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("Eliminar", oconexion);
                cmd.Parameters.AddWithValue("Clave", Clave);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Principal");
        }
    }
}