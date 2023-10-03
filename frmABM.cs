﻿using System;
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
    public partial class frmABM : Form
    {
        public frmABM()
        {
            InitializeComponent();
        }

        public static string rutaArchivoAbm;

        private void frmABM_Load(object sender, EventArgs e)
        {

        }

        private void cmdVolverABM_Click(object sender, EventArgs e)
        {
            frmVentanaGrilla frmVentanaGrilla = new frmVentanaGrilla();
            frmVentanaGrilla.Show();
            this.Close();
        }
        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text != "" & txtEntidad.Text != "" & txtApertura.Text != "" & txtNumeroDeExpediente.Text != "" & txtJuzgado.Text != "" & txtJurisdiccion.Text != "" & txtDireccion.Text != "" & txtLiquidadorResponsable.Text != "")
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void txtEntidad_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text != "" & txtEntidad.Text != "" & txtApertura.Text != "" & txtNumeroDeExpediente.Text != "" & txtJuzgado.Text != "" & txtJurisdiccion.Text != "" & txtDireccion.Text != "" & txtLiquidadorResponsable.Text != "")
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void txtApertura_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text != "" & txtEntidad.Text != "" & txtApertura.Text != "" & txtNumeroDeExpediente.Text != "" & txtJuzgado.Text != "" & txtJurisdiccion.Text != "" & txtDireccion.Text != "" & txtLiquidadorResponsable.Text != "")
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void txtNumeroDeExpediente_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text != "" & txtEntidad.Text != "" & txtApertura.Text != "" & txtNumeroDeExpediente.Text != "" & txtJuzgado.Text != "" & txtJurisdiccion.Text != "" & txtDireccion.Text != "" & txtLiquidadorResponsable.Text != "")
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void txtJuzgado_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text != "" & txtEntidad.Text != "" & txtApertura.Text != "" & txtNumeroDeExpediente.Text != "" & txtJuzgado.Text != "" & txtJurisdiccion.Text != "" & txtDireccion.Text != "" & txtLiquidadorResponsable.Text != "")
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void txtJurisdiccion_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text != "" & txtEntidad.Text != "" & txtApertura.Text != "" & txtNumeroDeExpediente.Text != "" & txtJuzgado.Text != "" & txtJurisdiccion.Text != "" & txtDireccion.Text != "" & txtLiquidadorResponsable.Text != "")
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text != "" & txtEntidad.Text != "" & txtApertura.Text != "" & txtNumeroDeExpediente.Text != "" & txtJuzgado.Text != "" & txtJurisdiccion.Text != "" & txtDireccion.Text != "" & txtLiquidadorResponsable.Text != "")
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }

        private void txtLiquidadorResponsable_TextChanged(object sender, EventArgs e)
        {
            if (txtNumero.Text != "" & txtEntidad.Text != "" & txtApertura.Text != "" & txtNumeroDeExpediente.Text != "" & txtJuzgado.Text != "" & txtJurisdiccion.Text != "" & txtDireccion.Text != "" & txtLiquidadorResponsable.Text != "")
            {
                btnGrabar.Enabled = true;
            }
            else
            {
                btnGrabar.Enabled = false;
            }
        }
        private void cmdModificar_Click_1(object sender, EventArgs e)
        {

            //ID es el Número
            string ID = txtNumero.Text;

            //Es una lista que funciona igual que un vector pero tiene métodos propios
            List<string> lineasArchivo = new List<string>();

            using (StreamReader reader = new StreamReader(rutaArchivoAbm))
            {
                // Lee el resto de las líneas
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    // Procesa la línea actual aquí y la separa los campos por ";"
                    string[] parametros = linea.Split(';');
                    //Copia todas las lineas que no coincide con el ID para sobreescribir el archivo sin la linea que debo borrar para poder sobreescribirla modificada
                    if (parametros[0] != ID)
                    {
                        lineasArchivo.Add(linea);
                    }
                    else
                    {
                        string nuevaLinea = txtNumero.Text + ";" + txtEntidad.Text + ";" + txtApertura.Text + ";" + txtNumeroDeExpediente.Text + ";" + txtJuzgado.Text + ";" + txtJurisdiccion.Text + ";" + txtDireccion.Text + ";" + txtLiquidadorResponsable.Text + ";";
                        lineasArchivo.Add(nuevaLinea);
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(rutaArchivoAbm))
            {
                foreach (string elemento in lineasArchivo)
                {
                    // Escribe cada elemento en una línea del archivo, el elemento contiene la línea guardada en el índice momentáneo de la lista
                    writer.WriteLine(elemento);
                }
            }

            MessageBox.Show("El registro fue modificado correctamente.");




            txtNumero.Clear();
            txtEntidad.Clear();
            txtApertura.Clear();
            txtNumeroDeExpediente.Clear();
            txtJuzgado.Clear();
            txtJurisdiccion.Clear();
            txtDireccion.Clear();
            txtLiquidadorResponsable.Clear();

            frmVentanaGrilla frmVentanaGrilla = new frmVentanaGrilla();
            frmVentanaGrilla.Show();
            this.Close();
        }
        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            string nuevaLinea = txtNumero.Text + ";" + txtEntidad.Text + ";" + txtApertura.Text + ";" + txtNumeroDeExpediente.Text + ";" + txtJuzgado.Text + ";" + txtJurisdiccion.Text + ";" + txtDireccion.Text + ";" + txtLiquidadorResponsable.Text + ";";

            // Agregar la nueva línea al archivo, usando los datos de la variable nuevaLinea que son los que se ingresan en los txt
            File.AppendAllText(rutaArchivoAbm, nuevaLinea + Environment.NewLine);

            MessageBox.Show("El registro fue grabado correctamente.");

            txtNumero.Clear();
            txtEntidad.Clear();
            txtApertura.Clear();
            txtNumeroDeExpediente.Clear();
            txtJuzgado.Clear();
            txtJurisdiccion.Clear();
            txtDireccion.Clear();
            txtLiquidadorResponsable.Clear();

            frmVentanaGrilla frmVentanaGrilla = new frmVentanaGrilla();
            frmVentanaGrilla.Show();
            this.Close();

            using (StreamReader reader = new StreamReader(@"../../bin/Debug/Proveedores/datosProveedor.csv"))
            {
                // Lee y descarta la primera línea (encabezado)
                reader.ReadLine();

                // Lee el resto de las líneas
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    // Procesa la línea actual aquí
                    string[] parametros = linea.Split(';');
                    //agregar a la datagrid
                    frmVentanaGrilla.dgvArchivito.Rows.Add(parametros);
                }
            }
        }
    }
}
