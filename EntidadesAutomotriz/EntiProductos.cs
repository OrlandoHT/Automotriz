
namespace EntidadesAutomotriz
{
    public class EntiProductos
    {
        private int _codigobarras;
        private string _nombre;
        private string _descripcion;
        private string _marca;

        public int Codigobarras { get => _codigobarras; set => _codigobarras = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Marca { get => _marca; set => _marca = value; }

        //CTRL + r + e -->Para generar los get/set.
    }
}
