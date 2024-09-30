using Sistema_scan_codigo_barras.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_scan_codigo_barras
{
    public partial class menuPrincipal : Form
    {

        public menuPrincipal()
        {
            InitializeComponent();
        }
        private void menuPrincipal_Load(object sender, EventArgs e)
        {
            lblTitulo.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            menuBuscar buscar = new menuBuscar();
            buscar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menuModificar modificar = new menuModificar();
            modificar.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
