using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;using Entity;
namespace BLL
{
public    class ProductoService
    {

        private ProductoDAO productoDAO;
        public ProductoService()
        {
            productoDAO = new ProductoDAO();
        }
        public string registrar(Producto pro)
        {
            string datos;
            // validaciones correspondientes
            datos = pro.IDProducto + ";" + pro.NombreProducto + ";" + pro.PrecioProducto + ";";
                    

            string mensaje = registrar(datos);
            return mensaje;
        }
     public void eliminar(int id) { productoDAO.eliminar(id); }
        public Pedido leerPorId(int id) { return productoDAO.leerPorId(id); }


        public List<Producto> listarTodos()
        {
            return productoDAO.listarTodos();
        }

    }
}
