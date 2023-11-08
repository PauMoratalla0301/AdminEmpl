using System;
using System.Data;
using System.Data.SqlClient;

namespace AdminEmpl.DAL
{
    internal class ConexionDALBase
    {

        internal DataSet EjecutarSentencia(SqlCommand sentencia)
        {
            throw new NotImplementedException();
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
    }
}