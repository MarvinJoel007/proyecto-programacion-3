using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace DAL
{
    public class PedidoDAO : BaseDatos, IPedido
    {
        public void actualizar(Pedido t)
        {

            try
            {
                string ssql;

                ssql = "UPDATE pedidos SET (@IdPedido,@tipoPedido,@decripcionPedido,@estado,@valorPedido) where IDPedido = @IdPedido ";
                var cmd = new SqlCommand(ssql, conexion);
                cmd.CommandText = ssql;
                cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = t.IDPedido;
                cmd.Parameters.Add("@tipoPedido", SqlDbType.VarChar).Value = t.TipoPedido;
                cmd.Parameters.Add("@descripcionPedido", SqlDbType.VarChar).Value = t.DescripcionPedido;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = t.Estado;
                cmd.Parameters.Add("@valorPedido", SqlDbType.Decimal).Value = t.ValorPedido;
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

        public void eliminar(int id)
        {


            try
            {

                SqlCommand cmd = new SqlCommand("Delete from pedidos where IDPedido = @IdPedido", conexion);
                cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = id;
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

        public Pedido leerPorId(int id)
        {


            try
            {
                Pedido pedido = new Pedido();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("Select * from pedidos where IDPedido = @IdPedido", conexion);
                cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = id;
                conectar();
                reader = cmd.ExecuteReader();
                reader.Read();
                pedido = map(reader);
                cerrar();
                return pedido;
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

        public List<Pedido> listarTodos()
        {

            try
            {
                List<Pedido> pedidos = new List<Pedido>();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("Select * from Pedidos", conexion);
                conectar();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pedido pedido = new Pedido();

                    pedido = map(reader);
                    pedidos.Add(pedido);
                }
                cerrar();
                return pedidos;


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
        Pedido map(SqlDataReader reader)
        {
            Pedido pedido = new Pedido();

            pedido.IDPedido = (int)reader["IDPedido"];
            pedido.TipoPedido = (string)reader["TipoPedido"];
            pedido.DescripcionPedido = (string)reader["DescripcionPedido"];
            pedido.Estado = (string)reader["Estado"];
            pedido.ValorPedido = (decimal)reader["ValorPedido"];

            return pedido;
        }

        public void registrar(Pedido t)
        {
            try
            {



                string ssql;
                ssql = "INSERT INTO [Pedidos]([IDPedidos],[TipoPedido],[DescriocionPedido],[Estado],[ValorPedido])VALUES(@IdPedido,@tipoPedido,@decripcionPedido,@estado,@valorPedido)";
                var cmd = new SqlCommand(ssql, conexion);
                cmd.CommandText = ssql;
                cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = t.IDPedido;
                cmd.Parameters.Add("@tipoPedido", SqlDbType.VarChar).Value = t.TipoPedido;
                cmd.Parameters.Add("@descripcionPedido", SqlDbType.VarChar).Value = t.DescripcionPedido;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = t.Estado;
                cmd.Parameters.Add("@valorPedido", SqlDbType.Decimal).Value = t.ValorPedido;


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
    }
}
