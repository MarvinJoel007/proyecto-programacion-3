using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Entity;
using System.Threading.Tasks;

namespace DAL
{
    public class ArchivoProducto
    {
       
        
        public string Ruta { get; set; }

        public ArchivoProducto(string ruta)
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

        public List<producto> consultar()
        {
            try
            {
                string linea;

                List<producto> lista = new List<producto>();
                lista.Clear();
                StreamReader lector = new StreamReader(Ruta);
                string[] aux;
                char delimitador = ';';
                while (!lector.EndOfStream)
                {
                    producto pro = new producto();
                    linea = lector.ReadLine();
                    aux = linea.Split(delimitador);
                    pro.IdProducto      = aux[0];
                    pro.nombreProducto  = aux[1];
                    pro.preciosProducto = aux[2];


                    lista.Add(pro);
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
