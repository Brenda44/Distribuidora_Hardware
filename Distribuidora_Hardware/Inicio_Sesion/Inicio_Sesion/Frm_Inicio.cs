using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Inicio_Sesion
{
    public partial class Frm_Inicio : Form
    {
        public Frm_Inicio()
        {
            InitializeComponent();
        }

        private void Frm_Inicio_Load(object sender, EventArgs e)
        {
            //Librerias System.Data.OleDb  y System.Data (son necesarias para realizar la conexion a la base de datos)
            //Crear un DataSet donde se almacenaran las consults que hay en acces
            DataSet resultados = new DataSet();

            try
            {
                string CADENA_CONEXION = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\DistDeHardware1" + "User Id=admin;Password=;";
                //MessageBox.Show(CADENA_CONEXION): Comprobar si es correcta la ruta
                //Application.StartupPath te manda a traer la cadena completa de la ruta solo se concatena el nombre de la base

                OleDbConnection objeto_conexion = new OleDbConnection(CADENA_CONEXION);
                objeto_conexion.Open();

                //Esta linea es la que ejecuta el comando de SQL 
                OleDbCommand comando_ejecutar = new OleDbCommand("SELECT usuario, contraseña, intentos FROM Administradores;", objeto_conexion);
                //Los datos del comando  oledbCommand los guarda temporalmente
                OleDbDataAdapter objeto_resultados = new OleDbDataAdapter(comando_ejecutar);
                comando_ejecutar.CommandType = CommandType.Text; //Tipo de comando que se ejecutara
                objeto_resultados.Fill(resultados, " Administradores");

                objeto_conexion.Close();

                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
