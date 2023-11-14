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
    public partial class frmCrearUsuario : Form
    {
        public frmCrearUsuario()
        {
            InitializeComponent();
        }
        //Publicos para mantener en el log.
        public static string usuarioCrearCuenta;
        public static string contraseñaCrearCuenta;
        public static string perfilCrearCuenta;
        
        private void frmCrearUsuario_Load(object sender, EventArgs e)
        {

        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Close();
        }

        private void cmdCrear_Click(object sender, EventArgs e)
        {
            usuarioCrearCuenta = txtUsuario.Text;
            contraseñaCrearCuenta = txtContrasena.Text;
            perfilCrearCuenta = txtPerfil.Text;
            clsLogs objLogs = new clsLogs();



              MessageBox.Show("Usuario registrado en la base de datos.");

              clsLogin objLogin = new clsLogin();

              objLogin.CrearCuenta();


              objLogs.RegistroLogCrearCuentaExitoso();
            
        }
    }
}
