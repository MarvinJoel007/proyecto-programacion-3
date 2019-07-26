using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class BaseDatos
    {

        protected const string cadenaConexion = "Server=.\\SQLEXPRESS;Database = AyB;User Id = sa;Password = 123456;";
        protected SqlConnection conexion;
        //protected SqlCommand cmd;
        public BaseDatos(SqlConnection cnn)
        {
            //cadenaConexion = "Server=.\\SQLEXPRESS;Database = AyB;User Id = sa;Password = 123456;";
            conexion = cnn;
        }

        public BaseDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }
        public void conectar()
        {
            
            try
            {
                conexion.Open();

            }
            catch (Exception ex)
            {
               
                throw new Exception(string.Format("BaseDatos.conectar:\n  {0}", ex.Message));
            }


        }
        public void cerrar()
        {
            try
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("BaseDatos.cerrar:\n  {0}", ex.Message));
            }
        }

        public string estado()
        {
            return conexion.State.ToString();
        }

    }
}