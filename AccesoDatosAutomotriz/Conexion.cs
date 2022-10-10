using MySql.Data.MySqlClient;
using System.Data;

namespace AccesoDatosAutomotriz
{
    public class Conexion
    {
        private MySqlConnection _conn;
        public Conexion(string servidor, string automotriz, string password, string basedatos, uint puerto)
        {
            MySqlConnectionStringBuilder cadenaConexion = new MySqlConnectionStringBuilder();
            cadenaConexion.Server = servidor;
            cadenaConexion.UserID = automotriz;
            cadenaConexion.Password = password;
            cadenaConexion.Database = basedatos;
            cadenaConexion.Port = puerto;

            _conn = new MySqlConnection(cadenaConexion.ToString());
        }
        public void EjecutarConsulta(string consulta)
        {
            _conn.Open();
            var command = new MySqlCommand(consulta, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }
        public DataSet ObtenerDatos(string consulta, string tabla)
        {
            var ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, _conn);
            da.Fill(ds, tabla);
            return ds;
        }
    }
}
