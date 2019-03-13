using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlHelper
    {
        SqlConnection conexion = new SqlConnection("Data Source=IMANOL-PC; Initial Catalog=iEspressoWeb; Integrated Security=SSPI;");
        SqlTransaction tx;

        void Iniciar()
        {
            tx = conexion.BeginTransaction();
        }

        public DataTable Leer(string consulta, SqlParameter[] parametros)
        {
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable tabla = new DataTable();
            adaptador.SelectCommand = new SqlCommand(consulta, conexion);
            if (parametros != null)
                adaptador.SelectCommand.Parameters.AddRange(parametros);
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            adaptador.Fill(tabla);
            adaptador = null;
            conexion.Close();
            return tabla;
        }

        public int Escribir(string consulta, SqlParameter[] parametros)
        {
            conexion.Open();
            Iniciar();
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            int filas=0;
            try
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);
                cmd.Transaction = tx;
                cmd.CommandType = CommandType.StoredProcedure;
                filas = cmd.ExecuteNonQuery();
                cmd = null;
                tx.Commit();
            }
            catch (SqlException ex)
            {
                tx.Rollback();
            }
            conexion.Close();
            return filas;
        }
    }
}
