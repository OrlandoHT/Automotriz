using System;
using System.Collections.Generic;
using EntidadesAutomotriz;
using System.Data;

namespace AccesoDatosAutomotriz
{
    public class AccesoHerramientas
    {
        Conexion con;
        public AccesoHerramientas()
        {
            con = new Conexion("localhost", "root", "", "automotriz", 3306);
        }
        public void GuardarHerramientas(EntiHerramientas herramienta)
        {
            string consulta = string.Format("Insert into herramientas values({0},'{1}','{2}','{3}','{4}')",
                herramienta.Codigoherramienta, herramienta.Nombre, herramienta.Medida, herramienta.Marca, herramienta.Descripcion);
            con.EjecutarConsulta(consulta);
        }
        public void EliminarHerramientas(int codigoherramienta)
        {
            string consulta = string.Format("Delete from herramientas where codigoherramienta={0}", codigoherramienta);
            con.EjecutarConsulta(consulta);
        }
        public void ModificarHerramientas(EntiHerramientas herramienta)
        {

            string consulta = string.Format("update herramientas set nombre='{0}', medida='{1}', marca='{2}', descripcion='{3}' where codigoherramienta = {4}",
                herramienta.Nombre, herramienta.Medida, herramienta.Marca, herramienta.Descripcion, herramienta.Codigoherramienta);
            con.EjecutarConsulta(consulta);
        }
        public List<EntiHerramientas> GetHerramientas(string dato)
        {
            var listHerramientas = new List<EntiHerramientas>();
            var ds = new DataSet();

            string consulta = string.Format("select * from herramientas where nombre like '%{0}%'", dato);
            ds = con.ObtenerDatos(consulta, "herramientas");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var herramienta = new EntiHerramientas
                {
                    Codigoherramienta = Convert.ToInt32(row["codigoherramienta"]),
                    Nombre = row["nombre"].ToString(),
                    Medida = row["medida"].ToString(),
                    Marca = row["marca"].ToString(),
                    Descripcion = row["descripcion"].ToString()
                };
                listHerramientas.Add(herramienta);
            }
            return listHerramientas;
        }
    }
}
