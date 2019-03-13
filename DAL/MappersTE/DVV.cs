using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DVV
    {
        SqlHelper sh = new SqlHelper();

        public List<BE.DVV> Listar()
        {
            DataTable tabla = sh.Leer("LISTAR_DVV", null);
            List<BE.DVV> ls = new List<BE.DVV>();

            foreach (DataRow r in tabla.Rows)
            {
                BE.DVV dvv = new BE.DVV();
                dvv.Tabla = (string)r["TABLA"];
                try
                {
                    dvv.Digito = (string)r["DVV"];
                }
                catch (Exception)
                {
                    dvv.Digito = null;
                    throw;
                }
                ls.Add(dvv);
            }
            return ls;
        }

        public int Insertar(BE.DVV dvv)
        {
            int fa;
            SqlParameter[] parametros = {
            new SqlParameter("@TABLA", dvv.Tabla),
            new SqlParameter("@DVV", dvv.Digito)
            };
            fa = sh.Escribir("INSERTAR_DVV", parametros);
            return fa;
        }

    }
}
