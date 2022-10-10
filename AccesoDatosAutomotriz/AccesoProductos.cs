using System;
using System.Collections.Generic;
using EntidadesAutomotriz;
using System.Data;

namespace AccesoDatosAutomotriz
{
    public class AccesoProductos
    {
        Conexion con;
        public AccesoProductos()
        {
            con = new Conexion("localhost", "root", "", "automotriz", 3306);
        }
        public void GuardarProductos(EntiProductos producto)
        {
            string consulta = string.Format("Insert into productos values({0},'{1}','{2}','{3}')", producto.Codigobarras, producto.Nombre, producto.Descripcion, producto.Marca);
            con.EjecutarConsulta(consulta);
        }
        public void EliminarProductos(int codigobarras)
        {
            string consulta = string.Format("Delete from productos where codigobarras={0}", codigobarras);
            con.EjecutarConsulta(consulta);
        }
        public void ModificarProductos(EntiProductos productos)
        {
            string consulta = string.Format("update productos set nombre='{0}', descripcion='{1}', marca='{2}' where codigobarras = {3}", productos.Nombre, productos.Descripcion, productos.Marca, productos.Codigobarras);
            con.EjecutarConsulta(consulta);
        }
        public List<EntiProductos> GetProductos(string dato)
        {
            var listProductos = new List<EntiProductos>();
            var ds = new DataSet();

            string consulta = string.Format("select * from productos where nombre like '%{0}%'", dato);
            ds = con.ObtenerDatos(consulta, "productos");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var productos = new EntiProductos
                {
                    Codigobarras = Convert.ToInt32(row["codigobarras"]),
                    Nombre = row["nombre"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Marca = row["marca"].ToString()
                };
                listProductos.Add(productos);
            }
            return listProductos;
        }
    }
}
