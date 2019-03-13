using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SEGURIDAD
{
    public class Backup
    {
        SqlConnection conexion = new SqlConnection("Data Source=IMANOL-PC; Initial Catalog=iEspressoWeb; Integrated Security=SSPI;");

        public string RealizarBackup(string rutaYnombre)
        {
            conexion.Open();
            string mensaje;
            string fecha = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "---" + DateTime.Now.Hour + "h" + DateTime.Now.Minute + "m" + DateTime.Now.Second + "s";
            string str1 = "USE iEspressoWeb;";
            string str2 = "BACKUP DATABASE iEspressoWeb TO DISK = '" + rutaYnombre + "-" + fecha + ".Bak';";
            SqlCommand cmd1 = new SqlCommand(str1, conexion);
            SqlCommand cmd2 = new SqlCommand(str2, conexion);

            try
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                mensaje = "Copia de seguridad realizada con exito.";
            }
            catch (SqlException ex)
            {
                mensaje = "No se pudo realizar el backup.";
            }
            conexion.Close();
            return mensaje;
        }

        public string Restaurar(string backup)
        {
            conexion.Open();
            string mensaje;
            string str1 = "USE master;";
            string str2 = "CREATE DATABASE iEspressoWeb;";
            string strAlter = "ALTER DATABASE iEspressoWeb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            string str3 = "RESTORE DATABASE iEspressoWeb FROM DISK = '" + backup + "' WITH REPLACE;";
            SqlCommand cmd1 = new SqlCommand(str1, conexion);
            SqlCommand cmd2 = new SqlCommand(str2, conexion);
            SqlCommand cmd3 = new SqlCommand(str3, conexion);
            SqlCommand cmdALTER = new SqlCommand(strAlter, conexion);

            try
            {
                cmd1.ExecuteNonQuery();
                cmdALTER.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                mensaje = "Restauracion completa. Se reiniciará la aplicacion.";
            }
            catch (SqlException ex)
            {
                try
                {
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    mensaje = "Restauracion completa. Se reiniciará la aplicacion.";
                }
                catch (SqlException ex2)
                {
                    mensaje = "No se pudo restaurar la base de datos.";
                }
            }

            conexion.Close();
            return mensaje;
        }
    }
}
