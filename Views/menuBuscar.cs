using Sistema_scan_codigo_barras.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_scan_codigo_barras.Vistas
{
    public partial class menuBuscar : Form
    {
        public menuBuscar()
        {
            InitializeComponent();
        }
        private void limpiar()
        {
            txtCodigoBuscar.Clear();
            txtCodigoBarrasDuplicado.Clear();
            txtCategoriaBuscar.Clear();
            txtDescripcionBuscar.Clear();
            txtMarcaBuscar.Clear();
            txtPrecioBuscar.Clear();
            imgBuscar.Image = null;  
        }
        private void activarTxt()
        {
            txtCategoriaBuscar.Enabled = true;
            txtDescripcionBuscar.Enabled = true;
            txtMarcaBuscar.Enabled = true;
            txtPrecioBuscar.Enabled = true;
            txtCodigoBarrasDuplicado.Enabled = true;
        }
        private void menuBuscar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void menuBuscar_Load(object sender, EventArgs e)
        {
            txtCodigoBuscar.Focus();
        }
        private void btnVolverBuscar_Click_1(object sender, EventArgs e)
        {
            menuPrincipal principal = new menuPrincipal();
            principal.Show();
            this.Hide();
        }
     
        #region "metodos de logica"
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.buscarProducto();
        }
        private void txtCodigoBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.buscarProducto();
               
            }

        }
        private void buscarProducto()
        {
            bool fallo = false;
            if (!string.IsNullOrWhiteSpace(txtCodigoBuscar.Text))
            {

                string codigo = txtCodigoBuscar.Text;
                Producto producto = new Producto();
                producto = ProductoDAO.Instancia.buscarProducto(codigo);

                if (producto != null)
                {

                    activarTxt();
                    txtCodigoBarrasDuplicado.Text = producto.codigoBarras.ToString();
                    txtCategoriaBuscar.Text = producto.categoriaProducto.ToString();
                    txtDescripcionBuscar.Text = producto.descripcion.ToString();
                    txtMarcaBuscar.Text = producto.marcaProducto.ToString();
                    txtPrecioBuscar.Text = producto.precio.ToString();
                    if(producto.imagenBytes != null)
                    {
                    using (MemoryStream ms = new MemoryStream(producto.imagenBytes))
                    {
                        imgBuscar.Image = Image.FromStream(ms);
                    }

                    }
                    else
                    {
                        imgBuscar.Image = null;
                    }
                    txtCodigoBuscar.Clear();
                    fallo = false;

                }
                else
                {
                    
                    fallo = true;
                    MessageBox.Show("Producto no encontrado. Por favor, verifica el código de barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else
            {
                fallo = true;
                MessageBox.Show("Ingrese un codigo de barra válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (fallo)
            {
                limpiar();
                txtCodigoBuscar.Focus();
            }
            
        }

        #endregion

    }
}

