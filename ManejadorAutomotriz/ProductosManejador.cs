using System.Collections.Generic;
using EntidadesAutomotriz;
using AccesoDatosAutomotriz;

namespace ManejadorAutomotriz
{
    public class ProductosManejador
    {
        private AccesoProductos _accesoProductos = new AccesoProductos();
        public List<EntiProductos> GetProductos(string dato)
        {
            var listProductos = _accesoProductos.GetProductos(dato);
            return listProductos;
        }
        public void GuardarProductos(EntiProductos producto)
        {
            _accesoProductos.GuardarProductos(producto);
        }
        public void EliminarProductos(int codigobarras)
        {
            _accesoProductos.EliminarProductos(codigobarras);
        }
        public void ModificarProductos(EntiProductos producto)
        {
            _accesoProductos.ModificarProductos(producto);
        }
    }
}
