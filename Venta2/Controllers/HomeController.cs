using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Venta2.Models;

namespace Venta2.Controllers
{
    public class HomeController : Controller
    {
        Examen1NetEntities1 contexto;
        public HomeController()
        {
            contexto = new Examen1NetEntities1();
        }
        public ActionResult Formulario()
        {

            return View();
        }

        public ActionResult Guardar( int rut, string nombre, string apellido, string tipocliente)
        {
            cliente nuevo = new cliente()
            {
               
                Rut = rut,
                Nombre = nombre,
                Apellido = apellido,
                Tipo_Cliente = tipocliente

            };
            contexto.cliente.Add(nuevo);
            contexto.SaveChanges();

            return View("Listado", contexto.cliente.ToList());
        }

        public ActionResult Listado()
        {

            return View(contexto.cliente.ToList());
        }


        public ActionResult Ficha(int rut)
        {

            return View(contexto.cliente.Where(x => x.Rut == rut).First());

        }

        public ActionResult FormularioProducto()
        {

            return View(contexto.Productos.ToList());
        }

        public ActionResult GuardarProducto(int codigobaarra, string nombre, string familia, string precio, string descuento, string descripcion)
        {
            Productos nuevo = new Productos()
            {
                 Nombre = nombre,
                CodigoBarra = codigobaarra,
               Familia = familia,
               Precio = precio,
                DescuentoTope= descuento,
                Descripcion= descripcion
            };
            contexto.Productos.Add(nuevo);
            contexto.SaveChanges();

            return View("ListadoProducto", contexto.Productos.ToList());
        }

    }
}