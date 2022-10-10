using System;
using System.Windows.Forms;
using ManejadorAutomotriz;
using EntidadesAutomotriz;

namespace Automotriz
{
    public partial class FrmHerramientas : Form
    {
        private HerramientasManejador _herramientasManejador;
        private string _Bandera;
        public FrmHerramientas()
        {
            InitializeComponent();
            _herramientasManejador = new HerramientasManejador();
        }

        private void FrmHerramientas_Load(object sender, EventArgs e)
        {
            LLenarHerramientas("");
            ControlarBotones(true, false, false, true);
            LimpiarCampos();
            ControlarCampos(false);
        }
        //SEPARACIÓN METODOS NORMALES.
        #region MetodosNormales
        private void LLenarHerramientas(string dato)
        {
            dgvHerramientas.DataSource = _herramientasManejador.GetHerramientas(dato);
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
            txtCodigoHerramienta.Text = "";
            txtNombre.Text = "";
            txtMedida.Text = "";
            txtMarca.Text = "";
            txtDescripcion.Text = "";
        }
        private void ControlarCampos(bool control)
        {
            txtCodigoHerramienta.Enabled = control;
            txtNombre.Enabled = control;
            txtMedida.Enabled = control;
            txtMarca.Enabled = control;
            txtDescripcion.Enabled = control;
        }
        private void GuardarHerramientas()
        {
            EntiHerramientas herramienta = new EntiHerramientas();
            herramienta.Codigoherramienta = Convert.ToInt32(txtCodigoHerramienta.Text);
            herramienta.Nombre = txtNombre.Text;
            herramienta.Medida = txtMedida.Text;
            herramienta.Marca = txtMarca.Text;
            herramienta.Descripcion = txtDescripcion.Text;
            _herramientasManejador.GuardarHerramientas(herramienta);
            
        }
        private void EliminarHerramientas()
        {
            var codigoherramienta = dgvHerramientas.CurrentRow.Cells["codigoherramienta"].Value;
            _herramientasManejador.EliminarHerramientas(Convert.ToInt32(codigoherramienta));
        }
        private void ModificarHerramientas()
        {
            _herramientasManejador.ModificarHerramientas(new EntiHerramientas
            {
                Codigoherramienta = Convert.ToInt32(txtCodigoHerramienta.Text),
                Nombre = txtNombre.Text,
                Medida = txtMedida.Text,
                Marca = txtMarca.Text,
                Descripcion = txtDescripcion.Text
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
                    GuardarHerramientas();
                    LLenarHerramientas("");
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    ModificarHerramientas();
                    LLenarHerramientas("");
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
            if (MessageBox.Show("¿Deseas eliminar este registro?", "ELIMINAR HERRAMIENTA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    EliminarHerramientas();
                    LLenarHerramientas("");
                    MessageBox.Show("El registro se elimino correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al intentar eliminar:(");
                }
            }
        }

        private void dgvHerramientas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Bandera = "actualizar";
                ControlarCampos(true);
                ControlarBotones(false, true, true, false);
                txtCodigoHerramienta.Text = dgvHerramientas.CurrentRow.Cells["codigoherramienta"].Value.ToString();
                txtNombre.Text = dgvHerramientas.CurrentRow.Cells["nombre"].Value.ToString();
                txtMedida.Text = dgvHerramientas.CurrentRow.Cells["medida"].Value.ToString();
                txtMarca.Text = dgvHerramientas.CurrentRow.Cells["marca"].Value.ToString();
                txtDescripcion.Text = dgvHerramientas.CurrentRow.Cells["descripcion"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar actualizar");
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            LLenarHerramientas(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
