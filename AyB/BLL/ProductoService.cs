using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
    public class ProductoService
    {

        private ArchivoProducto archivoProducto;

        public ProductoService(string ruta)
        {
            archivoProducto = new ArchivoProducto(ruta);
        }

        public string guardar(producto pro)
        {
            string datos;
            // validaciones correspondientes
            datos = pro.IdProducto + ";" + pro.nombreProducto + ";" +
                    pro.preciosProducto + ";";

            string mensaje = archivoProducto.guardar(datos);
            return mensaje;
        }

        public List<producto> listaProducto()
        {
            return archivoProducto.consultar();
        }
    }
}
