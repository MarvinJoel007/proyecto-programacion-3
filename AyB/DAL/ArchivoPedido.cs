using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using System.IO;using Entity;

namespace DAL
{
   public class ArchivoPedido
    {

        public string Ruta { get; set; }

        public ArchivoPedido(string ruta)
        {
            Ruta = ruta;
        }
        public string guardar(string datos)
        {
            try
            {
                // abrir el archivo
                StreamWriter escritor = new StreamWriter(Ruta, true);
                //operaciones 
                escritor.WriteLine(datos);
                escritor.Close();
                return "se agrego el registro correctamente";
            }
            catch (Exception e)
            {
                return "no se agrego el registro";
            }

        }

        public List<Pedido> consultar()
        {
            try
            {
                string linea;

                List<Pedido> lista = new List<Pedido>();
                lista.Clear();
                StreamReader lector = new StreamReader(Ruta);
                string[] aux;
                char delimitador = ';';
                while (!lector.EndOfStream)
                {
                    Pedido pedido = new Pedido();
                    linea = lector.ReadLine();
                    aux = linea.Split(delimitador);
                    pedido.tipoPedido = aux[0];
                    pedido.abono = Convert.ToDecimal(aux[1]);
                    pedido.especificacion= aux[2];
                    pedido.estado = aux[3];
                    pedido.fecha = Convert.ToDateTime(aux[4]);
                    pedido.fechaEntrega = Convert.ToDateTime(aux[5]);


                    lista.Add(pedido);
                }

                lector.Close();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
