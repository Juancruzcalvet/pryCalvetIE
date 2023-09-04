using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryCalvetIE
{
    public partial class frmArchivo : Form
    {
        public frmArchivo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarCarpetas.ShowDialog();
            lblEjemplo.Text = buscarCarpetas.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ruta = lblEjemplo.Text;
            ruta += textBox1.Text;
            StreamWriter manejoArchivo = new StreamWriter(ruta);
            MessageBox.Show("Archivo creado");
        }
    }
}
