using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryCalvetIE
{
    internal class clsLogs
    {
        OleDbConnection conexionBD;
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;

        OleDbDataAdapter adaptadorBD;
        DataSet objDS = new DataSet();

        string RutaConexionBase;


        public string estadoDeConexion;

        frmLogin frmLogin = new frmLogin();
        public clsLogs()
        {

            try
            {
                RutaConexionBase = @"Provider = Microsoft.ACE.OLEDB.12.0;Data Source = E:\Escritorio\IEFICalvet\ElClub\EL_CLUB.accdb";

                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = RutaConexionBase;
                conexionBD.Open();

                objDS = new DataSet();

                estadoDeConexion = "Conectado";
            }
            catch (Exception error)
            {
                estadoDeConexion = error.Message;
            }


            //Construimos para tener la conexión y comandos
            conexionBD = new OleDbConnection();
            comandoBD = new OleDbCommand();
        }

        public void ConectarBD()
        {
            try
            {
                string conexion = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\Escritorio\IEFICalvet\ElClub\EL_CLUB.accdb";

                conexionBD.ConnectionString = conexion;
                conexionBD.Open();

            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }

        public void RegistroLogInicioSesionExitoso()
        {
            try
            {
                ConectarBD();

                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;

                //Buscamos tabla
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                //Aqui indicamos cual tabla
                comandoBD.CommandText = "Logs";
                //Adaptamos para pasar al dataset
                adaptadorBD = new OleDbDataAdapter(comandoBD);
                //Guardamos en dataset
                adaptadorBD.Fill(objDS, "Logs");
                //Obtengo una referencia a la tabla
                DataTable objTabla = objDS.Tables["Logs"];
                //Creamos fila para almacenar datos
                DataRow nuevoRegistro = objTabla.NewRow();
                //Llenamos el log con los datos del inicio de sesion
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Accion"] = "Inicio de sesión";
                nuevoRegistro["Usuario"] = frmLogin.Nombre;
                //Añadimos lo agregado al dataset a la tabla de BD
                objTabla.Rows.Add(nuevoRegistro);
                //Creo el objeto OledBCommandBuilder pasando como parámetro el DataAdapter
                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                //Actualizo la base con los cambios realizados
                adaptadorBD.Update(objDS, "Logs");
                estadoDeConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {
                estadoDeConexion = error.Message;
            }
        }

        public void RegistroLogInicioSesionFallido()
        {
            //Lo mismo que antes pero lo hacemos en caso de que alguien falle su inicio de sesion.
            try
            {
                ConectarBD();
                comandoBD = new OleDbCommand();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Logs";
                adaptadorBD = new OleDbDataAdapter(comandoBD);
                adaptadorBD.Fill(objDS, "Logs");
                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();
                nuevoRegistro["Accion"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Usuario"] = frmLogin.Nombre;
                objTabla.Rows.Add(nuevoRegistro);
                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");
                estadoDeConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {

                estadoDeConexion = error.Message;
            }
        }

        



        public void RegistroLogCrearCuentaExitoso()
        {
            //Lo mismo que antes pero lo hacemos en caso de crear una cuenta nueva.
            try
            {
                ConectarBD();

                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Logs";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                adaptadorBD.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Accion"] = "Crear cuenta";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Usuario"] = frmCrearUsuario.usuarioCrearCuenta;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");

                estadoDeConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {
                estadoDeConexion = error.Message;
            }
        }

       


        public void RegistroLogBuscarClientePorId()
        {
            try
            {
                //Lo mismo que antes pero lo hacemos en caso de que use la busqueda por id en El formulario de ELCLUB
                ConectarBD();

                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Logs";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                adaptadorBD.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Accion"] = "Buscar socio por ID";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Usuario"] = frmLogin.Nombre;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");

                estadoDeConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {
                estadoDeConexion = error.Message;
            }
        }


        public void RegistroLogVerSociosDelClub()
        {
            try
            {
                //Lo mismo que antes pero lo hacemos en caso de que abra El formulario de ELCLUB y vea la grilla
                ConectarBD();

                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Logs";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                adaptadorBD.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Accion"] = "Ver socios del club";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Exitoso";
                nuevoRegistro["Usuario"] = frmLogin.Nombre;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");

                estadoDeConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {
                estadoDeConexion = error.Message;
            }
        }


 
        public void RegistroLogCambiarEstado()
        {
            try
            {
                //Lo mismo que antes pero lo hacemos en caso de que abra El formulario de ELCLUB y cambie el estado de un o varios clientes.
                ConectarBD();

                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Logs";

                adaptadorBD = new OleDbDataAdapter(comandoBD);

                adaptadorBD.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Accion"] = "Cambiar estado de socio";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Exitoso";
                nuevoRegistro["Usuario"] = frmLogin.Nombre;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");

                estadoDeConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {
                estadoDeConexion = error.Message;
            }
        }
    }
}
