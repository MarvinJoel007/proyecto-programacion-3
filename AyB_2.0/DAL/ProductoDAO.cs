using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDAO : BaseDatos, IProducto
    { 
        public void eliminar(int id)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("Delete from productos where IDProducto = @IdProducto", conexion);
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = id;
                conectar();
                cmd.ExecuteNonQuery();

                cerrar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cerrar();
            }
        }
        
        Producto map(SqlDataReader reader)
        {
            Producto producto = new Producto();

           producto.IDProducto = (int)reader["IDProducto"];
           producto.NombreProducto = (string)reader["NombreProducto"]; 
           producto.PrecioProducto = (decimal)reader["Precioproducto"];

            return producto;
        }


       public List<Producto> listarTodos()
        {

            try
            {
                List<Producto> productos = new List<Producto>();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("Select * from Pedidos", conexion);
                conectar();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto();

                    producto = map(reader);
                    productos.Add(producto);
                }
                cerrar();
                return productos;


            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cerrar();
            }

        }

       public Producto leerPorId(int id)
        {

            try
            {
                Producto producto = new Producto();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("Select * from productos where IDProducto = @IdProducto", conexion);
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = id;
                conectar();
                reader = cmd.ExecuteReader();
                reader.Read();
                producto = map(reader);
                cerrar();
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                cerrar();
            }
        }

        public void registrar(Producto t)
        {

            try
            {



                string ssql;
                ssql = "INSERT INTO [Productos]([IDProducto],[NombreProducto],[PrecioProducto])VALUES(@IdProducto,@nombreProducto,@precioProducto)";
                var cmd = new SqlCommand(ssql, conexion);
                cmd.CommandText = ssql;
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = t.IDProducto;
                cmd.Parameters.Add("@nombreProducto", SqlDbType.VarChar).Value = t.NombreProducto;
                cmd.Parameters.Add("@PrecioProducto", SqlDbType.Decimal|).Value = t.PrecioProducto;


                conectar();
                int i = cmd.ExecuteNonQuery();

                cerrar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cerrar();
            }

        }

        public void actualizar(Producto t)
        {

            try
            {
                string ssql;

                ssql = "UPDATE pedidos SET (@IdProducto,@nombreProducto,@precioProducto) where IDPedido = @IdProducto ";
                var cmd = new SqlCommand(ssql, conexion);
                cmd.CommandText = ssql;
                cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = t.IDProducto;
                cmd.Parameters.Add("@nombreProducto", SqlDbType.VarChar).Value = t.NombreProducto;
                cmd.Parameters.Add("@valorProducto", SqlDbType.Decimal).Value = t.PrecioProducto;
                conectar();
                cmd.ExecuteNonQuery();
                cerrar();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cerrar();
            }
        }
    }
}
