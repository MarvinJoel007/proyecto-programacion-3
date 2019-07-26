using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;using DAL;
namespace BLL
{
    public class PedidoService
    {
        private PedidoDAO pedidoDAO;
        public PedidoService()
        {
            pedidoDAO =new PedidoDAO();
        }
        public string registrar(Pedido ped)
        {
            string datos;
            // validaciones correspondientes
            datos = ped.ID_pedido + ";" + ped.Tipo_pedido + ";" + ped.Descripcion_pedido + ";"+
                    ped.Estado + ";" + ped.ValorPedido + ";";

            string mensaje = registrar(datos);
            return mensaje;
        }

        public List<Pedido> listarTodos()
        {
            return pedidoDAO.listarTodos();
        }
    }
}
