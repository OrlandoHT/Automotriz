using System.Collections.Generic;
using EntidadesAutomotriz;
using AccesoDatosAutomotriz;

namespace ManejadorAutomotriz
{
    public class HerramientasManejador
    {
        private AccesoHerramientas _accesoHerramientas = new AccesoHerramientas();
        public List<EntiHerramientas> GetHerramientas(string dato)
        {
            var listHerramienta = _accesoHerramientas.GetHerramientas(dato);
            return listHerramienta;
        }
        public void GuardarHerramientas(EntiHerramientas herramienta)
        {
            _accesoHerramientas.GuardarHerramientas(herramienta);
        }
        public void EliminarHerramientas(int codigoherramienta)
        {
            _accesoHerramientas.EliminarHerramientas(codigoherramienta);
        }
        public void ModificarHerramientas(EntiHerramientas herramienta)
        {
            _accesoHerramientas.ModificarHerramientas(herramienta);
        }
    }
}
