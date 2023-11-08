using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using AdminEmpl.BLL;

namespace AdminEmpl.DAL
{
    class DepartamentosDAL
    {
        ConexionDAL conexion;

        public DepartamentosDAL()
        {


            conexion = new ConexionDAL();

        }

        public bool Agregar(DepartamentoBLL oDepartamentosBLL)
        {
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Departamentos VALUES (@Departamento)");
            SQLComando.Parameters.Add("@",SqlDbType.VarChar).Value=oDepartamentosBLL.Departamento;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);


           // return conexion.ejecutarComandoSinRetornoDatos("INSERT INTO Departamentos (departamento) VALUES ('+oDepatamentosBLL.Departamento+')");
            
            

            
        }

        public bool Eliminar(DepartamentoBLL oDepartartamentosBLL)
        {
            SqlCommand SQLComando = new SqlCommand ("DELETE FROM Departamentos WHERE ID=@ID");
            SQLComando.Parameters.Add("ID", SqlDbType.Int).Value = oDepartartamentosBLL.ID;
            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);

            

        }

        public bool Modificar(DepartamentoBLL oDepartartamentosBLL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Departamentos SET Departamento=@ WHERE ID=@ID");
            SQLComando.Parameters.Add ("@Departamento", SqlDbType.VarChar).Value = oDepartartamentosBLL.Departamento;
            SQLComando.Parameters.Add("ID", SqlDbType.Int).Value = oDepartartamentosBLL.Departamento;

            return conexion.ejecutarComandoSinRetornoDatos(SQLComando);

        }
        public DataSet MostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Departamentos");
            return conexion.EjecutarSentencia(sentencia);


        }

    }
}
