using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Security.Policy;

namespace pryCalvetIE
{
    
    internal class clsLogin
    {
        //A través de esto establecemos conexión a base de datos
        OleDbConnection Conexion_BD = new OleDbConnection();
        //A través de esta enviamos comandos a la base de datos
        OleDbCommand Comando_BD = new OleDbCommand();
        //La ultilizamos para leer lo que hay en la base de datos
        OleDbDataReader Leer_BD;
        //Nos permite actualizar la base de datos y permite llenar el dataset
        OleDbDataAdapter Adaptador_BD;
        

        // Objeto DataSet para llenar con lo que tenga la tabla de la BD
        DataSet objDS = new DataSet(); 
        //String vacio para recibir estado de la base de datos
        public string EstadoConexion = "";
        //Ruta de base de datos
        string ConexionUsuarios = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\ElClub\EL_CLUB.accdb";
        //Booleano de acceso, verdadero o falso. Indica si estas o no dentro de la BD
        public static bool acceso;
        public clsLogin()
        {
            try
            {
                //Creo una nueva instancia de la clase OleDbConecction en la memoria
                Conexion_BD = new OleDbConnection();

                //Establezco la ruta de la BD
                Conexion_BD.ConnectionString = ConexionUsuarios;

                //Abro la conexión con la base de datos 
                Conexion_BD.Open();

                //Creo una instancia de la clase DataSet que voy a usar para contener datos de la BD
                objDS = new DataSet();

                EstadoConexion = "Conectado";
            }
            catch (Exception error)
            {
                EstadoConexion = error.Message;
            }

            //Creo las instancias para la conexión y el comando.
            Conexion_BD = new OleDbConnection();
            Comando_BD = new OleDbCommand();
        }

        public void ConectarBD()
        {
            try
            {
                //Establezco ruta de la base de datos 
                Conexion_BD.ConnectionString = ConexionUsuarios;
                //Abro la conexión con la base de datos 
                Conexion_BD.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show(Convert.ToString(error));
            }
        }

        public void BuscarUsuario()
        {
            try
            {
                ConectarBD();

                //Creo una instancia de la clase OleDbCommand para ejecutar los comandos en la base de datos (buscar, agregar, etc.)
                Comando_BD = new OleDbCommand();

                //Establezco la conexión con la BD, así podemos operar en ella
                Comando_BD.Connection = Conexion_BD;

                //Comando para leer una tabla deseada
                Comando_BD.CommandType = System.Data.CommandType.TableDirect;

                //Le digo que tabla es la que se va a leer
                Comando_BD.CommandText = "Usuarios";

                //Ejecuto el comando y leo la los resultados de la consulta
                Leer_BD = Comando_BD.ExecuteReader();

                //Si tiene filas lee lo que hay dentro
                if (Leer_BD.HasRows)
                {
                    while (Leer_BD.Read())
                    {
                        //Almaceno los datos del registro en dos variables distintas
                        //Columna[1] (contendrá el campo Usuario), columna[2] (contiene el campo Contraseña)
                        //Así podremos compararlas más tarde con lo escrito en el txt
                        string usuarioBD = Leer_BD[1].ToString();
                        string contraseñaBD = Leer_BD[2].ToString();

                        //Si la contraseña corresponde al usuario elegido
                        //la variable booleana acceso va a ser verdadera y rompo el bucle
                        if (usuarioBD == frmLogin.Nombre & contraseñaBD == frmLogin.Contrasena)
                        {
                            acceso = true;
                            break;
                            
                        }
                        else
                        {
                            acceso = false;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                EstadoConexion = error.Message;
            }
        }


        public void TraerDatosElClub(DataGridView grilla)
        {
            //Estos nos sirven para "traducir" lo que dice la tabla.
            string estadoCliente = "";
            string sexo = "";

            try
            {
                //Abrimos BD
                Comando_BD = new OleDbCommand();
                Comando_BD.Connection = Conexion_BD;
                //Buscamos tabla
                Comando_BD.CommandType = System.Data.CommandType.TableDirect;
                Comando_BD.CommandText = "SOCIOS";

                //Ejecuto un comando y creo un lector de datos para leer los resultados 
                Leer_BD = Comando_BD.ExecuteReader();

                grilla.Columns.Add("ID", "ID");
                grilla.Columns.Add("Nombre", "Nombre");
                grilla.Columns.Add("Apellido", "Apellido");
                grilla.Columns.Add("Nacionalidad", "Nacionalidad");
                grilla.Columns.Add("Edad", "Edad");
                grilla.Columns.Add("Sexo", "Sexo");
                grilla.Columns.Add("Ingreso", "Ingreso");
                grilla.Columns.Add("Puntaje", "Puntaje");
                grilla.Columns.Add("Estado", "Estado");

                if (Leer_BD.HasRows)
                {
                    while (Leer_BD.Read())
                    {
                        if (Leer_BD.GetBoolean(8) == true)
                        {
                            estadoCliente = "Activo";
                        }
                        else
                        {
                            estadoCliente = "Inactivo";
                        }

                        if (Leer_BD.GetBoolean(5) == true)
                        {
                            sexo = "Masculino";
                        }
                        else
                        {
                            sexo = "Femenino";
                        }

                        grilla.Rows.Add(Leer_BD[0], Leer_BD[1], Leer_BD[2], Leer_BD[3], Leer_BD[4], sexo, Leer_BD[6], Leer_BD[7], estadoCliente);

                    }
                }
            }
            catch (Exception error)
            {
                EstadoConexion = "Error:" + error.Message;
            }
        }

        public void BuscarPorCodigoDatosElClub(int codigoSocio)
        {
            try
            {
                Comando_BD = new OleDbCommand();
                Comando_BD.Connection = Conexion_BD;
                Comando_BD.CommandType = System.Data.CommandType.TableDirect;
                Comando_BD.CommandText = "SOCIOS";
                Leer_BD = Comando_BD.ExecuteReader();
                //Booleano para saber si se encuentra el ID deseado o no.
                bool seEncuentra = false;
                //mientras haya filas
                if (Leer_BD.HasRows)
                {
                    //leemos registro por registro
                    while (Leer_BD.Read())
                    {
                        //si ID = a lo ingresado por txt
                        if (int.Parse(Leer_BD[0].ToString()) == codigoSocio)
                        {
                            MessageBox.Show("Cliente existente: \n" + Leer_BD[1].ToString() + " " + Leer_BD[2].ToString(), "Consulta");
                            seEncuentra = true;
                            break;
                        }
                    }

                    if (seEncuentra == false)
                    {
                        MessageBox.Show("Cliente no existe", "Consulta");
                    }
                }
            }
            catch (Exception error)
            {
                EstadoConexion = "Error:" + error.Message;
            }
        }

       
        public void CrearCuenta()
        {
            try
            {
                ConectarBD();

                Comando_BD = new OleDbCommand();
                Comando_BD.Connection = Conexion_BD;
                Comando_BD.CommandType = System.Data.CommandType.TableDirect;
                Comando_BD.CommandText = "Usuarios";
                //Adaptamos la BD
                Adaptador_BD = new OleDbDataAdapter(Comando_BD);
                //Llenamos el dataset con los usuarios registrados
                Adaptador_BD.Fill(objDS, "Usuarios");
                DataTable objTabla = objDS.Tables["Usuarios"];
                //Creo la nueva fila
                DataRow nuevoRegistro = objTabla.NewRow();
                //Asigno los valores a todos los campos de la fila
                nuevoRegistro["Usuario"] = frmCrearUsuario.usuarioCrearCuenta;
                nuevoRegistro["Contraseña"] = frmCrearUsuario.contraseñaCrearCuenta;
                nuevoRegistro["Perfil"] = frmCrearUsuario.perfilCrearCuenta;
                //Agrego el DataRow a la tabla
                objTabla.Rows.Add(nuevoRegistro);
                //Lo contrario al adapter, ahora buscamos volver a "traducirlo" al idioma Access
                OleDbCommandBuilder constructor = new OleDbCommandBuilder(Adaptador_BD);
                //Actualizo la base con los cambios realizados
                Adaptador_BD.Update(objDS, "Usuarios");
                EstadoConexion = "Cuenta creada con éxito";
            }
            catch (Exception error)
            {
                EstadoConexion = error.Message;
            }
        }

        public void ModificarEstadoSocio(int id)
        {
            OleDbCommand Comando_BD = new OleDbCommand();
            OleDbDataAdapter objAdaptador;
            DataSet objDataSet = new DataSet();

            try
            {
               
                Conexion_BD = new OleDbConnection();                
                Conexion_BD.ConnectionString = ConexionUsuarios;                
                Conexion_BD.Open();
                EstadoConexion = "Conectado";

            }
            catch (Exception ex)
            {
                
                EstadoConexion = "Error" + ex.Message;
            }

        
            Comando_BD.Connection = Conexion_BD;
            Comando_BD.CommandType = CommandType.TableDirect;
            Comando_BD.CommandText = "SOCIOS";
            objAdaptador = new OleDbDataAdapter(Comando_BD);
            //Llenamos el dataset
            objAdaptador.Fill(objDataSet, "SOCIOS");
            //Obtenemos los datos del dataset
            DataTable dt = objDataSet.Tables["SOCIOS"];
            //Itero sobre cada fila de la tabla
            foreach (DataRow registro in dt.Rows)
            {
                //Comparo si el valor de código socio es igual al id ingresado por el usuario
                if ((int)registro["CODIGO_SOCIO"] == id)
                {
                    //Editamos
                    registro.BeginEdit();

                    //Cambiamos según sea el estado del socio
                    if ((bool)registro["ESTADO"])
                    {
                        registro["ESTADO"] = false;
                    }
                    else
                    {
                        registro["ESTADO"] = true;
                    }

                    //Finalizamos la edición de la fila 
                    registro.EndEdit();

                    //Rompemos bucle
                    break;
                }
            }

            //Construimos la tabla
            OleDbCommandBuilder constructor = new OleDbCommandBuilder(objAdaptador);

            //Actualizamos la base de datos
            objAdaptador.Update(objDataSet, "SOCIOS");

            MessageBox.Show("Estado alterado.");
        }
    }
}


