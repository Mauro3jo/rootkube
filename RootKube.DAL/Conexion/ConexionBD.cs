using System;
using System.Data.SqlClient;

namespace RootKube.DAL.Conexion
{
    public class ConexionBD
    {
        private readonly string connectionString = "Server=localhost;Database=RootKube;Integrated Security=True";

        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }
    }
}
