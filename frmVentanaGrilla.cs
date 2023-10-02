using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCalvetIE
{
    public partial class frmVentanaGrilla : Form
    {
        public frmVentanaGrilla()
        {
            InitializeComponent();
        }
        public static string rutaArchivoGrilla;

        private void frmVentanaGrilla_Load(object sender, EventArgs e)
        {

        }
        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            frmABM frmABM = new frmABM();

            //Hago que cuente la cantidad de filas de la grilla y pone el número siguiente en el txt de la ventana ABM 
            int contadoraDeFilas = dgvArchivito.Rows.Count;
            string ultimoNumero = dgvArchivito.Rows[contadoraDeFilas - 1].Cells[0].Value.ToString();
            int numeroDelTxt = Convert.ToInt32(ultimoNumero) + 1;
            frmABM.txtNumero.Text = numeroDelTxt.ToString();
            frmABM.txtNumero.ReadOnly = true;


            frmABM.cmdModificar.Visible = false;
            frmABM.btnGrabar.Visible = true;
            frmABM.rutaArchivoAbm = rutaArchivoGrilla;
            frmABM.Show();
            this.Hide();
        }
        private void cmdModificar_Click(object sender, EventArgs e)
        {
            //En la variable n guardo el indice de la fila seleccionada en la grilla
            int n = dgvArchivito.CurrentCell.RowIndex;

            frmABM frmABM = new frmABM();

            //El ReadOnly solo deja ver el contenido del txt no deja que se modifique
            frmABM.txtNumero.ReadOnly = true;
            //Cargo todos los txt del formulario ABM para que solo modifique lo que quiera, sin tener que cargar todo de nuevo
            frmABM.txtNumero.Text = dgvArchivito.Rows[n].Cells[0].Value.ToString();
            frmABM.txtEntidad.Text = dgvArchivito.Rows[n].Cells[1].Value.ToString();
            frmABM.txtApertura.Text = dgvArchivito.Rows[n].Cells[2].Value.ToString();
            frmABM.txtNumeroDeExpediente.Text = dgvArchivito.Rows[n].Cells[3].Value.ToString();
            frmABM.txtJuzgado.Text = dgvArchivito.Rows[n].Cells[4].Value.ToString();
            frmABM.txtJurisdiccion.Text = dgvArchivito.Rows[n].Cells[5].Value.ToString();
            frmABM.txtDireccion.Text = dgvArchivito.Rows[n].Cells[6].Value.ToString();
            frmABM.txtLiquidadorResponsable.Text = dgvArchivito.Rows[n].Cells[7].Value.ToString();

            string ID = Convert.ToString(dgvArchivito.Rows[n].Cells[0].Value);

            frmABM.cmdModificar.Visible = true;
            frmABM.btnGrabar.Visible = false;
            frmABM.rutaArchivoAbm = rutaArchivoGrilla;
            frmABM.Show();
            this.Hide();
        }
        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            
            //n es el número de fila seleccionado en la grilla
            int n = dgvArchivito.CurrentCell.RowIndex;

            if (n != -1)
            {
                //ID es el número de la celda 0 de la fila seleccionada 
                string ID = Convert.ToString(dgvArchivito.Rows[n].Cells[0].Value);

                //Es una lista que funciona igual que un vector pero tiene métodos propios
                List<string> lineasArchivo = new List<string>();

                using (StreamReader reader = new StreamReader(rutaArchivoGrilla))
                {

                    // Lee el resto de las líneas
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        // Procesa la línea actual aquí y separo los campos con ";"
                        string[] parametros = linea.Split(';');
                        //Copia todas las lineas que no coincide con el ID para sobreescribir el archivo sin la linea que quiero borrar
                        if (parametros[0] != ID)
                        {
                            lineasArchivo.Add(linea);
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(rutaArchivoGrilla))
                {
                    foreach (string elemento in lineasArchivo)
                    {
                        // Escribe cada elemento en una línea del archivo, el elemento contiene la línea guardada en el índice momentáneo de la lista
                        writer.WriteLine(elemento);
                    }
                }

                MessageBox.Show("El registro fue eliminado correctamente.");

                dgvArchivito.Rows.RemoveAt(n);
            }
        }
        private void cmdVolver_Click(object sender, EventArgs e)
        {
            frmVistaProveedores frmVistaProveedores= new frmVistaProveedores();
            frmVistaProveedores.Show();
            this.Close();

        }
    }
}
