using System;
using System.Windows.Forms;
using ManejadorAutomotriz;
using EntidadesAutomotriz;

namespace Automotriz
{
    public partial class FrmProductos : Form
    {
        private ProductosManejador _productosManejador;
        private string _Bandera;

        public FrmProductos()
        {
            InitializeComponent();
            _productosManejador = new ProductosManejador();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            LLenarProductos("");
            ControlarBotones(true, false, false, true);
            LimpiarCampos();
            ControlarCampos(false);
        }

        #region MetodosNormales
        private void LLenarProductos(string dato)
        {
            dgvProductos.DataSource = _productosManejador.GetProductos(dato);
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
            txtCodigoDeBarras.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtMarca.Text = "";
        }
        private void ControlarCampos(bool control)
        {
            txtCodigoDeBarras.Enabled = control;
            txtNombre.Enabled = control;
            txtDescripcion.Enabled = control;
            txtMarca.Enabled = control;
        }
        private void GuardarProductos()
        {
            EntiProductos producto = new EntiProductos();
            producto.Codigobarras = Convert.ToInt32(txtCodigoDeBarras.Text);
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Marca = txtMarca.Text;
            _productosManejador.GuardarProductos(producto);
        }
        private void EliminarProductos()
        {
            var codigobarras = dgvProductos.CurrentRow.Cells["codigobarras"].Value;
            _productosManejador.EliminarProductos(Convert.ToInt32(codigobarras));
        }
        private void ModificarProductos()
        {
            _productosManejador.ModificarProductos(new EntiProductos
            {
                Codigobarras = Convert.ToInt32(txtCodigoDeBarras.Text),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Marca = txtMarca.Text
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
                    GuardarProductos();
                    LLenarProductos("");
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    ModificarProductos();
                    LLenarProductos("");
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
            if (MessageBox.Show("¿Deseas eliminar este registro?", "ELIMINAR PRODUCTO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    EliminarProductos();
                    LLenarProductos("");
                    MessageBox.Show("El registro se elimino correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al intentar eliminar:(");
                }
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Bandera = "actualizar";
                ControlarCampos(true);
                ControlarBotones(false, true, true, false);
                txtCodigoDeBarras.Text = dgvProductos.CurrentRow.Cells["codigobarras"].Value.ToString();
                txtNombre.Text = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells["descripcion"].Value.ToString();
                txtMarca.Text = dgvProductos.CurrentRow.Cells["marca"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar actualizar");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            LLenarProductos(txtBuscar.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
