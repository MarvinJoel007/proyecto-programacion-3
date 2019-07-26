using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pedido
    {
        public int ID_pedido { get; set; }
        public string Tipo_pedido { get; set; }
        public string Descripcion_pedido { get; set; }
        public string Estado { set; get; }
        public decimal ValorPedido { get;set; }
    }
}
