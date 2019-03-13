using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MapperID
    {
        public static int ObtenerNuevoID(string tablaBD)
        {
            SqlHelper sh = new SqlHelper();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TABLA", tablaBD);
            DataTable tabla = sh.Leer("OBTENER_NUEVO_ID", param);
            int ID = 0;
            foreach (DataRow r in tabla.Rows)
                ID = (int)r["ID"];
            return ID;
        }
    }
}
