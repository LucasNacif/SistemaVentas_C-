using Sistema_scan_codigo_barras.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sistema_scan_codigo_barras.Vistas
{
    public partial class menuModificar : Form
    {
        public menuModificar()
        {
            InitializeComponent();

        }
        private void menuModificar_Load(object sender, EventArgs e)

        {
            txtCodigo.Focus();
        }

        #region "variables"
        int nEstado = 0;
        string mensajeDeError;
        #endregion


        #region "metodos para las vistas"
        private void estadoTexto(bool estado)
        {

            txtDescripcion.ReadOnly = !estado;
            txtMarca.ReadOnly = !estado;
            txtCategoria.ReadOnly = !estado;
            txtPrecio.ReadOnly = !estado;
        }
        private void limpiaTexto()
        {
            txtCodigo.Clear();
            txtCodigoBarrasDuplicado.Clear();
            txtPrecio.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            txtDescripcion.Clear();
            imgPanelControl.Image = null;
        }
        private void limpiaTextoExcluyendoCodigoBarras()
        {
            txtCodigo.Clear();
            txtPrecio.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            txtDescripcion.Clear();
            imgPanelControl.Image = null;
        }
        private void reiniciarColorPanel()
        {
            btnNuevo.BackColor = SystemColors.ControlLightLight;
            btnModificar.BackColor = SystemColors.ControlLightLight;
            btnEliminar.BackColor = SystemColors.ControlLightLight;
            btnVolver.BackColor = SystemColors.ControlLightLight;
            PanelPrincipal.BackColor = SystemColors.ScrollBar;
        }
        private void estadoBotonesProcesos(bool estado)
        {
            btnGuardarProducto.Visible = estado;
            btnCargarImg.Visible = estado;
            btnCancelar.Visible = estado;
            btnLimpiar.Visible = estado;
        }
        private void EstablecerEstado(int estado, string textoBoton, Color colorBoton, Button botonActivo)
        {
            reiniciarColorPanel();
            txtCodigo.Focus();
            nEstado = estado;
            btnGuardarProducto.Text = textoBoton;
            this.estadoTexto(true);
            this.estadoBotonesProcesos(true);
            botonActivo.BackColor = SystemColors.Highlight;
            PanelPrincipal.BackColor = SystemColors.Highlight;
            botonActivo.Enabled = true;
        }
        private void menuModificar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion



        //BOTONES PRINCIPALES
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EstablecerEstado(1, "Guardar", SystemColors.Highlight, btnNuevo);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            EstablecerEstado(2, "Actualizar", SystemColors.Highlight, btnModificar);
        }
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            EstablecerEstado(3, "Eliminar", SystemColors.Highlight, btnEliminar);
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            reiniciarColorPanel();
            menuPrincipal principal = new menuPrincipal();
            principal.Show();
            this.Hide();
        }
       
        
        #region "metodos de logica"
        //BOTONES DE PROCESOS
        private void PbEnter_MouseEnter(object sender, EventArgs e)
        {
            string rutaRelativa = Path.Combine(Application.StartupPath, "Resources", "TeclaEnterPresionada.png");
            Console.WriteLine(rutaRelativa);
            PbEnter.Image = Image.FromFile(rutaRelativa);
        }
        private void PbEnter_MouseLeave(object sender, EventArgs e)
        {
            string rutaRelativa2 = Path.Combine(Application.StartupPath, "Resources", "TeclaEnter.png");
            Console.WriteLine(rutaRelativa2);
            PbEnter.Image = Image.FromFile(rutaRelativa2);
        }
        private void PbEnter_Click(object sender, EventArgs e)
        {
            buscarParaActualizar();
        }
        private void btnCargarImg_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
                    openFileDialog.Title = "Seleccionar imagen del producto";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (imgPanelControl.Image != null)
                        {
                            imgPanelControl.Image.Dispose();
                        }

                        using (var bmpTemp = new Bitmap(openFileDialog.FileName))
                        {
                            imgPanelControl.Image = new Bitmap(bmpTemp);
                        }

                        txtRutaImagen.Text = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nEstado = 0;
            this.estadoTexto(false);
            this.limpiaTexto();
            this.estadoBotonesProcesos(false);
            this.reiniciarColorPanel();
            txtCodigo.Focus();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiaTexto();
            txtCodigo.Focus();
        }
        private bool validaciones()
        {
            float precio;
               
            // Validaciones de campos obligatorios
            if (nEstado == 1 || nEstado == 2)//si esta en la seccion de guardar y modificar
            {
                if (!string.IsNullOrWhiteSpace(txtCodigoBarrasDuplicado.Text) && !string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (txtCodigoBarrasDuplicado.Text != txtCodigo.Text)
                    {
                        mensajeDeError = "Los códigos de barras ingresados son diferentes. Por favor, asegúrese de que sean iguales o deje uno de los campos en blanco.";
                        return false;
                    }

                }
                if (string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    mensajeDeError = "Por favor, completa todos los campos obligatorios que tienen el asterisco (*)";
                    return false;
                }

                if (!float.TryParse(txtPrecio.Text, out precio))
                {
                    mensajeDeError = "El precio debe ser un número válido.";
                    return false;
                }
            }else if (nEstado == 3)
            {
                if (string.IsNullOrWhiteSpace(txtCodigoBarrasDuplicado.Text) && string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    mensajeDeError = "Ingrese el codigo de barras del producto que desea elminar por favor.";
                    return false;
                }
            }
           


            return true;

        }
        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {

            if (validaciones())
            {
                Producto producto = new Producto();
                

                if (!string.IsNullOrWhiteSpace(txtCodigoBarrasDuplicado.Text))
                {
                    producto.codigoBarras = txtCodigoBarrasDuplicado.Text;
                }
                else if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    producto.codigoBarras = txtCodigo.Text;
                }
                else
                {
                    MessageBox.Show("Por favor, escanee o ingrese un código de barras válido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if (nEstado != 3)
                {
                    producto.marcaProducto = txtMarca.Text;
                    producto.precio = float.Parse(txtPrecio.Text);  
                    producto.categoriaProducto = txtCategoria.Text;
                    producto.descripcion = txtDescripcion.Text;
                 

                    if (!string.IsNullOrEmpty(txtRutaImagen.Text))//si hay una nueva imagen
                    {
                        producto.imagenBytes = ProductoDAO.Instancia.ConvertirImagenABytes(txtRutaImagen.Text);//se convierte a byte
                        txtRutaImagen.Clear();
                    }
                    else
                    {
                        producto.imagenBytes = null;
                    }

                }
                GuardarModificarEliminarProducto(producto);

            }
            else
            {
                MessageBox.Show(mensajeDeError, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();  
            }

        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buscarParaActualizar();

            }
        }
        private void menuModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Por favor seleccione la opcion que quiere realizar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

        }
        private void ManejarProductoNoEncontrado()
        {
            if (nEstado != 1)//Si el boton de guardar aun no ha sido seleccionado
            {
                MessageBox.Show("El producto escaneado no ha sido guardado aún", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnNuevo_Click(this, EventArgs.Empty);
            txtCodigoBarrasDuplicado.Text = txtCodigo.Text;
            limpiaTextoExcluyendoCodigoBarras();
        }
        private void ManejarProductoExistente(Producto producto)
        {
            // Manejar casos de modificar o eliminar
            if (nEstado != 2 || nEstado != 3)//Si lo botones de eliminar o modificar no ha sido apretados
            {
            MessageBox.Show("Se encontró un producto con este codigo de barra, puede modificarlo o eliminarlo si lo desea", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnModificar_Click(this, EventArgs.Empty);
            CargarDatosProducto(producto);
           
        }
        private void CargarDatosProducto(Producto producto)
        {
            txtCodigoBarrasDuplicado.Text = producto.codigoBarras.ToString();
            txtCategoria.Text = producto.categoriaProducto.ToString();
            txtDescripcion.Text = producto.descripcion.ToString();
            txtMarca.Text = producto.marcaProducto.ToString();
            txtPrecio.Text = producto.precio.ToString();

            if (producto.imagenBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(producto.imagenBytes))
                {
                    imgPanelControl.Image = Image.FromStream(ms);
                }
            }
            else
            {
                imgPanelControl.Image = null;
            }
            txtCodigo.Clear();

        }
        private void buscarParaActualizar()
        {
            // Validar que el campo de texto no esté vacío
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese un codigo de barra válido", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear instancias necesarias
            Producto producto = ProductoDAO.Instancia.buscarProducto(txtCodigo.Text);
            if (producto != null)
            {
                ManejarProductoExistente(producto);
            }
            else
            {
                ManejarProductoNoEncontrado();
            }

        }
        private void GuardarModificarEliminarProducto(Producto productoParaGuardarActualizar)
        {
           
            bool operacionExitosa = false;


            switch (nEstado)
            {

                case 1: // Guardar
                    Producto productoGuardado = ProductoDAO.Instancia.buscarProducto(productoParaGuardarActualizar.codigoBarras);

                    if (productoGuardado == null)//si el producto que se quiere guardar no existe entonces:
                    {
                        operacionExitosa = ProductoDAO.Instancia.guardarYactualizarProductos(productoParaGuardarActualizar, false);
                    }
                    else
                    {
                        MessageBox.Show("El producto que intenta guardar ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case 2: // Actualizar
                    Producto productoEncontradoParaModificar = ProductoDAO.Instancia.buscarProducto(productoParaGuardarActualizar.codigoBarras);
                    if (productoEncontradoParaModificar != null)
                    {
                      if (productoParaGuardarActualizar.imagenBytes == null)//si el producto que quiero actualizar no tiene una imagen nueva asignada
                        {
                        //busco la imagen del producto que quiero actualizar y se la vuelvo a asignar
                        byte[] imgDeProductoActualizar = ProductoDAO.Instancia.buscarImgProducto(productoParaGuardarActualizar.codigoBarras);

                        if (imgDeProductoActualizar != null)//si el producto tiene una imagen
                        {
                            productoParaGuardarActualizar.imagenBytes = imgDeProductoActualizar;//le vuelvo a asignar la misma imagen

                        }
                    }
                    operacionExitosa = ProductoDAO.Instancia.guardarYactualizarProductos(productoParaGuardarActualizar, true);
                    }
                    else
                    {
                        MessageBox.Show("No puede modificar un producto que no ha sido guardado aun", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case 3: // Eliminar
                    Producto productoEncontrado = ProductoDAO.Instancia.buscarProducto(productoParaGuardarActualizar.codigoBarras);
                    if (productoEncontrado != null)
                    {
                        operacionExitosa = ProductoDAO.Instancia.eliminarProducto(productoParaGuardarActualizar.codigoBarras);
                    }
                    else
                    {
                        MessageBox.Show("El producto que intenta eliminar no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                default:
                    MessageBox.Show("No ha seleccionado ningun operacion del panel de control", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Mostrar el mensaje adecuado según la operación
            if (operacionExitosa)
            {
                string mensaje = nEstado == 1 ? "Producto guardado correctamente." :
                                 nEstado == 2 ? "Producto actualizado correctamente." :
                                 "Producto eliminado correctamente.";
                MessageBox.Show(mensaje, "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hubo un error, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpiar los campos y enfocar el código de barras
            limpiaTexto();
            txtCodigo.Focus();
        }

        #endregion

    }
}