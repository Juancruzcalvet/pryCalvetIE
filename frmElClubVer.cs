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
    public partial class frmElClubVer : Form
    {
        clsLogin objDS;
        clsLogs objLogs;

        public string Nombre;
        public string Perfil;

        public frmElClubVer()
        {
            InitializeComponent();
        }

        private void frmElClubVer_Load(object sender, EventArgs e)
        {
            //Agregamos al log que el usuario vio la grilla
            clsLogs objLogs = new clsLogs();
            objLogs.RegistroLogVerSociosDelClub();
            //Conectamos a BD
            objDS = new clsLogin();
            objDS.ConectarBD();
            //Mostramos en label
            lblEstadoConexion.Text = objDS.EstadoConexion;
            lblEstadoConexion.BackColor = Color.Green;
            //Mostramos en grilla
            objDS.TraerDatosElClub(dgvElClub);


        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal frmPrincipal = new frmPrincipal(Nombre, Perfil);
            frmPrincipal.Show();
            this.Close();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            //Instanciamos en la memoria la clase con sus intrucciones
            clsLogs objLogs = new clsLogs();
            //Usamos metodo de la clase
            objLogs.RegistroLogBuscarClientePorId();

            //Usamos lo escrito en el txt para buscar en la BD
            objDS.BuscarPorCodigoDatosElClub(int.Parse(txtID.Text));
        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            //Igualamos lo escrito en txt en la variable
            id = Convert.ToInt32(txtActividad.Text);
            //Instanciamos las instrucciones
            clsLogin objLogin = new clsLogin();
            //Llamamos metodo
            objLogin.ModificarEstadoSocio(id);

            //Guardamos en logs lo hecho
            clsLogs objLogs = new clsLogs();
            objLogs.RegistroLogCambiarEstado();

        }
    }
}
