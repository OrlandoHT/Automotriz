using System;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido Orlando Hernández Torres\n Tienes acceso a todos los modulos");
            FrmMenuModulos m = new FrmMenuModulos();
            m.ShowDialog();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
