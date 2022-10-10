
namespace EntidadesAutomotriz
{
    public class EntiHerramientas
    {
        private int _codigoherramienta;
        private string _nombre;
        private string _medida;
        private string _marca;
        private string _descripcion;

        //CTRL + r + e -->Para generar los get/set.

        public int Codigoherramienta { get => _codigoherramienta; set => _codigoherramienta = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Medida { get => _medida; set => _medida = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
