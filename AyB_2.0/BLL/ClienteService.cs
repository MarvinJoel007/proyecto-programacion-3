using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;using DAL;
namespace BLL
{
public    class ClienteService
    {
        private ClienteDAO clienteDAO;
        public ClienteService()
        {
            clienteDAO = new ClienteDAO();
        }
        //public void actulizar(Cliente cliente) { return clienteDAO.actualizar(cliente.IDCliente); }
        //public void registrar(){ clienteDAO.registrar();}
        public void eliminar(int id) { clienteDAO.eliminar(id); }
        public Cliente leerPorId(int id) { return clienteDAO.leerPorId(id); }
        public List<Cliente> listarTodos()
        {
            return clienteDAO.listarTodos();
        }

    }
}
