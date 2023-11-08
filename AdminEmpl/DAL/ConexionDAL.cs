using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdminEmpl.DAL
{
    class ConexionDAL
    {


        private string CadenaConexion = "Data source =DESKTOP-AUC5GFM\\SQLEXPRESS; Initial Catalog = db.sistema; Integrated Security = True";

        SqlConnection Conexion;

        public SqlConnection EstablecerConexion()
        {

            this.Conexion = new SqlConnection(this.CadenaConexion);

            return this.Conexion;
        }

        public bool ejecutarComandoSinRetornoDatos(string strcomando)
        {

            try
            {


                SqlCommand Comando = new SqlCommand();

                Comando.CommandText = strcomando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool ejecutarComandoSinRetornoDatos(SqlCommand SQLcomando)
        {

            try
            {
                SqlCommand Comando = SQLcomando;

                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

        private DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();

            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;


            }

        }

        internal DataSet EjecutarSentencia(SqlCommand sentencia)
        {
            throw new NotImplementedException();
        }
    }
}



