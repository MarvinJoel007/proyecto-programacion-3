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
        public string registrar(Cliente Clie)
        {
            string datos;
            // validaciones correspondientes
            datos = Clie.IDCliente + ";" + Clie.NombreCliente + ";" + Clie.Direccion + ";" +
                    Clie.Telefono + ";";

            string mensaje = registrar(datos);
            return mensaje;
        }

        public List<Cliente> listarTodos()
        {
            return clienteDAO.listarTodos();
        }

    }
}
