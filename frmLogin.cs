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
    public partial class frmLogin : Form
    {
        public static string Nombre;
        public static string Contrasena;
        clsLogin objLogin;
        clsLogs objLogs;
        public frmLogin()
        {
            InitializeComponent();

            KeyPreview = true;
            //Cerramos la app si apretamos escape
            this.KeyDown += CerrarFrm_KeyDown;
        }
        //Cerramos la aplicacion con escape
        public void CerrarFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        DateTime Fecha;
        string Accion;
        int contador = 0;
        private void cmdEntrar_Click(object sender, EventArgs e)
        {   
            Nombre = txtUsuario.Text;
            Contrasena = txtContrasena.Text;

            clsLogin login = new clsLogin();
            login.BuscarUsuario();

            clsLogs objLogs = new clsLogs();
            if (clsLogin.acceso == true)
            {
                objLogs.RegistroLogInicioSesionExitoso();


                this.Hide();
                frmPrincipal frmPrincipal = new frmPrincipal();
                frmPrincipal.Show();
            }
            else
            {
                objLogs.RegistroLogInicioSesionFallido();

                contador = contador + 1;
                MessageBox.Show("Usuario o contraeña incorrectos");

                if (contador > 2)
                {
                    this.Close();
                }
            }

            txtUsuario.Text = " ";
            txtContrasena.Text = "";
            txtUsuario.Focus();
        }

        private void cmdCrearUsuario_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && e.KeyChar == 13)
            {
                txtContrasena.Focus();
                e.Handled = true;
            }
        }
    }
}




