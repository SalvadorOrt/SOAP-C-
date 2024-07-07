using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication8
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        prueba_flaskEntities contexto = new prueba_flaskEntities();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public List<Productos> ListarProductos()
        {
            return contexto.Productos.ToList();
        }

        [WebMethod]
        public Productos ListarProductosXid(int id)
        {
            return contexto.Productos.Find(id);
        }


        [WebMethod]
        public bool InsertarProducto(String nombre, decimal precio, int categoria_id)
        {
            try
            {
                Productos productos = new Productos { nombre = nombre,precio = precio, categoria_id = categoria_id };
                contexto.Productos.Add(productos);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;   
            }
        }
        [WebMethod]
        public string UpdateProducto(int id, string nombre, decimal precio, int categoria_id)
        {
            try
            {
                Productos producto = contexto.Productos.Find(id);
                if (producto == null)
                {
                    return "Producto no encontrado";
                }
                producto.nombre = nombre;
                producto.precio = precio;
                producto.categoria_id = categoria_id;
                contexto.SaveChanges();
                return "Producto actualizado con éxito";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        [WebMethod]
        public string DeleteProducto(int id)
        {
            try
            {
                Productos producto = contexto.Productos.Find(id);
                if (producto == null)
                {
                    return "Producto no encontrado";
                }
                contexto.Productos.Remove(producto);
                contexto.SaveChanges();
                return "Producto eliminado con éxito";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
