
namespace EntidadesAutomotriz
{
    public class EntiUsuarios
    {
        private int _idusuario;
        private string _nombreCompleto;
        private string _fechanacimiento;
        private string _rfc;
        private string _correo;
        private string _password;

        public int Idusuario { get => _idusuario; set => _idusuario = value; }
        public string NombreCompleto { get => _nombreCompleto; set => _nombreCompleto = value; }
        public string Fechanacimiento { get => _fechanacimiento; set => _fechanacimiento = value; }
        public string Rfc { get => _rfc; set => _rfc = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Password { get => _password; set => _password = value; }
        //CTRL + r + e -->Para generar los get/set.

    }
}
