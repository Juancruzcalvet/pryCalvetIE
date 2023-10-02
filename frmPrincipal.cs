using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCalvetIE
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void cargarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void vistaDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmVistaProveedores frmVistaProveedores = new frmVistaProveedores();
            frmVistaProveedores.Show();
        }
        private void cargaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
