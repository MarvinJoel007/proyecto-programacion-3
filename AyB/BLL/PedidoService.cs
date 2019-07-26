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
        private ArchivoPedido archivoPedido;
        public PedidoService(string ruta)
        {
            archivoPedido = new ArchivoPedido(ruta);
        }

        public string guardar(Pedido pedido)
        {
            string datos;
            // validaciones correspondientes
            datos = pedido.tipoPedido + ";" + pedido.abono + ";" + pedido.especificacion + ";" 
                    + pedido.estado + ";"+ pedido.fecha + ";"+ pedido.fechaEntrega + ";";

            string mensaje = archivoPedido.guardar(datos);
            return mensaje;
        }

        public List<Pedido> listaPedido()
        {
            return archivoPedido.consultar();
        }
    }

}
