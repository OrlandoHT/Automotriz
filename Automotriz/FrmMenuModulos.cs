using System;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class FrmMenuModulos : Form
    {
        public FrmMenuModulos()
        {
            InitializeComponent();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tienes Acceso al formulario de Productos y puedes hacer modificaciones");
            FrmProductos p = new FrmProductos();
            p.ShowDialog();
        }

        private void herramientasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tienes Acceso al formulario de Herramientas y puedes hacer modificaciones");
            FrmHerramientas h = new FrmHerramientas();
            h.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void administradorDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tienes Acceso al formulario de Herramientas y puedes hacer modificaciones");
            FrmUsuarios u = new FrmUsuarios();
            u.ShowDialog();
        }
    }
}
