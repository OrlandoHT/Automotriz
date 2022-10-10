using System;
using System.Collections.Generic;
using EntidadesAutomotriz;
using System.Data;

namespace AccesoDatosAutomotriz
{
    public class AccesoUsuarios
    {
        Conexion con;
        public AccesoUsuarios()
        {
            con = new Conexion("localhost", "root", "", "automotriz", 3306);
        }
        public void GuardarUsuarios(EntiUsuarios usuario)
        {
            string consulta = string.Format("Insert into usuarios values({0},'{1}','{2}','{3}','{4}','{5}')",
                usuario.Idusuario, usuario.NombreCompleto, usuario.Fechanacimiento, usuario.Rfc, usuario.Correo, usuario.Password);
            con.EjecutarConsulta(consulta);
        }
        public void EliminarUsuarios(int idUsuario)
        {
            string consulta = string.Format("Delete from usuarios where idusuario={0}", idUsuario);
            con.EjecutarConsulta(consulta);
        }
        public void ModificarUsuarios(EntiUsuarios usuario)
        {

            string consulta = string.Format("update usuarios set nombrecompleto ='{0}', fechanacimiento='{1}', rfc='{2}', correo='{3}', password='{4}' where idusuario = {5}",
                usuario.NombreCompleto, usuario.Fechanacimiento, usuario.Rfc, usuario.Correo, usuario.Password, usuario.Idusuario);
            con.EjecutarConsulta(consulta);
        }
        public List<EntiUsuarios> GetUsuarios(string dato)
        {
            var listUsuarios = new List<EntiUsuarios>();
            var ds = new DataSet();

            string consulta = string.Format("select * from usuarios where nombrecompleto like '%{0}%'", dato);
            ds = con.ObtenerDatos(consulta, "usuarios");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var usuario = new EntiUsuarios
                {
                    Idusuario = Convert.ToInt32(row["idusuario"]),
                    NombreCompleto = row["nombrecompleto"].ToString(),
                    Fechanacimiento = row["fechanacimiento"].ToString(),
                    Rfc = row["rfc"].ToString(),
                    Correo = row["correo"].ToString(),
                    Password = row["password"].ToString()

                };
                listUsuarios.Add(usuario);
            }
            return listUsuarios;
        }
    }
}
