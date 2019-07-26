using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICrud<T>
    {
        List<T> listarTodos();
        T leerPorId(int id);
        void registrar(T t);
        void actualizar(T t);
        void eliminar(int id);
    }
}
