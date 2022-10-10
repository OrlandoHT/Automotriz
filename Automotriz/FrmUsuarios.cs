using System;
using System.Windows.Forms;
using ManejadorAutomotriz;
using EntidadesAutomotriz;

namespace Automotriz
{
    public partial class FrmUsuarios : Form
    {
        private UsuariosManejador _usuarioManejador;
        private string _Bandera;

        public FrmUsuarios()
        {
            InitializeComponent();
            _usuarioManejador = new UsuariosManejador();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            LLenarUsuarios("");
            ControlarBotones(true, false, false, true);
            LimpiarCampos();
            ControlarCampos(false);
        }
        //SEPARACIÓN METODOS NORMALES.
        #region MetodosNormales
        private void LLenarUsuarios(string dato)
        {
            dgvUsuarios.DataSource = _usuarioManejador.GetUsuarios(dato);
        }
        private void ControlarBotones(bool nuevo, bool guardar, bool cancelar, bool eliminar)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnCancelar.Enabled = cancelar;
            btnEliminar.Enabled = eliminar;
        }
        private void LimpiarCampos()
        {
            txtIDUsuario.Text = "";
            txtNombreCompleto.Text = "";
            txtFechaNacimiento.Text = "";
            txtRfc.Text = "";
            txtCorreo.Text = "";
            txtPassword.Text = "";
        }
        private void ControlarCampos(bool control)
        {
            txtIDUsuario.Enabled = control;
            txtNombreCompleto.Enabled = control;
            txtFechaNacimiento.Enabled = control;
            txtRfc.Enabled = control;
            txtCorreo.Enabled = control;
            txtPassword.Enabled = control;
        }
        private void GuardarUsuario()
        {
            EntiUsuarios usuario = new EntiUsuarios();
            usuario.Idusuario = Convert.ToInt32(txtIDUsuario.Text);
            usuario.NombreCompleto = txtNombreCompleto.Text;
            usuario.Fechanacimiento = txtFechaNacimiento.Text;
            usuario.Rfc = txtRfc.Text;
            usuario.Correo = txtCorreo.Text;
            usuario.Password = txtPassword.Text;
            _usuarioManejador.GuardarUsuarios(usuario);
        }
        private void EliminarUsuario()
        {
            var idUsuario = dgvUsuarios.CurrentRow.Cells["idusuario"].Value;
            _usuarioManejador.EliminarUsuarios(Convert.ToInt32(idUsuario));
        }
        private void ModificarUsuario()
        {
            _usuarioManejador.ModificarUsuarios(new EntiUsuarios
            {
                Idusuario = Convert.ToInt32(txtIDUsuario.Text),
                NombreCompleto = txtNombreCompleto.Text,
                Fechanacimiento = txtFechaNacimiento.Text,
                Rfc = txtRfc.Text,
                Correo = txtCorreo.Text,
                Password = txtPassword.Text
            });
        }
        #endregion //Metodos.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ControlarBotones(false, true, true, false);
            ControlarCampos(true);
            _Bandera = "guardar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarBotones(true, false, false, true);
                if (_Bandera == "guardar")
                {
                    GuardarUsuario();
                    LLenarUsuarios("");
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    ModificarUsuario();
                    LLenarUsuarios("");
                    MessageBox.Show("Se actualizó correctamente");
                }
                LimpiarCampos();
                ControlarCampos(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlarBotones(true, false, false, true);
            LimpiarCampos();
            ControlarCampos(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas eliminar este registro?", "ELIMINAR USUARIO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    EliminarUsuario();
                    LLenarUsuarios("");
                    MessageBox.Show("El registro se elimino correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al intentar eliminar:(");
                }
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Bandera = "actualizar";
                ControlarCampos(true);
                ControlarBotones(false, true, true, false);
                txtIDUsuario.Text = dgvUsuarios.CurrentRow.Cells["idusuario"].Value.ToString();
                txtNombreCompleto.Text = dgvUsuarios.CurrentRow.Cells["nombrecompleto"].Value.ToString();
                txtFechaNacimiento.Text = dgvUsuarios.CurrentRow.Cells["fechanacimiento"].Value.ToString();
                txtRfc.Text = dgvUsuarios.CurrentRow.Cells["rfc"].Value.ToString();
                txtCorreo.Text = dgvUsuarios.CurrentRow.Cells["correo"].Value.ToString();
                txtPassword.Text = dgvUsuarios.CurrentRow.Cells["password"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar actualizar");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            LLenarUsuarios(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
