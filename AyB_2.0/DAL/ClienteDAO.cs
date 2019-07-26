using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class ClienteDAO : BaseDatos, ICliente
    {
        public void actualizar(Cliente t)
        {
            try
            {
                string ssql;
                //ssql= "UPDATE[clientes]([IDCliente],[NombreCliente],[Direccion],[Telefono])SET (@IdCliente, @nombreCliente, @direccion, @telefono) where IDCliente = @IdCliente";
                ssql= "UPDATE clientes SET (@IdCliente, @nombreCliente, @direccion, @telefono) where IDCliente = @IdCliente ";
                var cmd = new SqlCommand(ssql, conexion);
                cmd.CommandText = ssql;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = t.IDCliente;
                cmd.Parameters.Add("@nombreClinete", SqlDbType.VarChar).Value = t.NombreCliente;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = t.Direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = t.Telefono;
                conectar();
                cmd.ExecuteNonQuery();
                cerrar();

            }
            catch(Exception ex)
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

                SqlCommand cmd = new SqlCommand("Delete from clientes where IDCliente = @IdCliente", conexion);
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = id;
                conectar();
                cmd.ExecuteNonQuery();

                cerrar();

            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cerrar();
            }
        }
        Cliente map(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();
            cliente.IDCliente = (int)reader["IDCliente"];
            cliente.NombreCliente = (string)reader["NombreCliente"];
            cliente.Direccion = (string)reader["Direccion"];
            cliente.Telefono = (int)reader["Telefon"];
            
            return cliente;
        }

        public Cliente leerPorId(int id)
        {

            try
            {
                Cliente cliente = new Cliente();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("Select * from clientes where IDCliente = @IdCliente", conexion);
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = id;
                conectar();
                reader = cmd.ExecuteReader();
                reader.Read();
                cliente = map(reader);
                cerrar();
                return cliente;
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

       public List<Cliente> listarTodos()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("Select * from clientes", conexion);
                conectar();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    
                    cliente = map(reader);
                    clientes.Add(cliente);
                }
                cerrar();
                return clientes;


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


        public void registrar(Cliente t)
        {
            try
            {
                
      
      
    string ssql;
                ssql = "INSERT INTO [Clientes]([IDCliente],[NombreCliente],[Direccion],[Telefono])VALUES(@IdCliente,@nombreCliente,@direccion,@telefono)";
                var cmd = new SqlCommand(ssql, conexion);
                cmd.CommandText = ssql;
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = t.IDCliente;
                cmd.Parameters.Add("@nombreClinete", SqlDbType.VarChar).Value = t.NombreCliente;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = t.Direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = t.Telefono;

                 
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
