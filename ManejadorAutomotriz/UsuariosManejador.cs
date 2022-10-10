using System.Collections.Generic;
using EntidadesAutomotriz;
using AccesoDatosAutomotriz;

namespace ManejadorAutomotriz
{
    public class UsuariosManejador
    {
        private AccesoUsuarios _accesoUsuarios = new AccesoUsuarios();

        public List<EntiUsuarios> GetUsuarios(string dato)
        {
            var listUsuarios = _accesoUsuarios.GetUsuarios(dato);
            return listUsuarios;
        }
        public void GuardarUsuarios(EntiUsuarios usuario)
        {
            _accesoUsuarios.GuardarUsuarios(usuario);
        }
        public void EliminarUsuarios(int idUsuario)
        {
            _accesoUsuarios.EliminarUsuarios(idUsuario);
        }
        public void ModificarUsuarios(EntiUsuarios usuario)
        {
            _accesoUsuarios.ModificarUsuarios(usuario);
        }
    }
}
