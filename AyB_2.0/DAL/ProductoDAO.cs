using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDAO : BaseDatos, IProducto
    {
        public void actualizar(IProducto t)
        {
            throw new NotImplementedException();
        }

        public void eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public IProducto leerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<IProducto> listarTodos()
        {
            throw new NotImplementedException();
        }

        public void registrar(IProducto t)
        {
            throw new NotImplementedException();
        }
    }
}
