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
    public partial class frmCarga : Form
    {
        public frmCarga()
        {
            InitializeComponent();
        }

        private void frmCarga_Load(object sender, EventArgs e)
        {

        }

        private void timerBarra_Tick(object sender, EventArgs e)
        {
            pbCarga.Increment(5);
            lblPorcentaje.Text = pbCarga.Value.ToString() + "%";

            if (pbCarga.Value == pbCarga.Maximum)
            {
                timerBarra.Stop();
                this.Hide();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }
        }
    }
}
