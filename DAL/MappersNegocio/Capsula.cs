using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Capsula
    {
        SqlHelper sh = new SqlHelper();

        public List<BE.Capsula> Listar()
        {
            DataTable tabla = sh.Leer("LISTAR_CAPSULAS", null);
            List<BE.Capsula> ls = new List<BE.Capsula>();
            foreach (DataRow r in tabla.Rows)
            {
                BE.Capsula c = new BE.Capsula();
                c.ID = (int)r["ID"];
                c.Nombre = (string)r["NOMBRE"];
                c.Intensidad = (int)r["INTENSIDAD"];
                c.Descripcion = (string)r["DESCRIPCION"];
                c.Tipo = (string)r["TIPO"];
                c.Precio = Convert.ToSingle(r["PRECIO"]);
                c.Stock = (int)r["STOCK"];
                c.DVH = (string)r["DVH"];
                ls.Add(c);
            }
            return ls;
        }

        public BE.Capsula Obtener(int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@ID", id);
            DataTable tabla = sh.Leer("OBTENER_CAPSULA", parametro);
            BE.Capsula c = new BE.Capsula();

            if (tabla.Rows.Count == 0)
                c = null;
            else
            {
                foreach (DataRow r in tabla.Rows)
                {
                    c.ID = (int)r["ID"];
                    c.Nombre = (string)r["NOMBRE"];
                    c.Intensidad = (int)r["INTENSIDAD"];
                    c.Descripcion = (string)r["DESCRIPCION"];
                    c.Tipo = (string)r["TIPO"];
                    c.Precio = Convert.ToSingle(r["PRECIO"]);
                    c.Stock = (int)r["STOCK"];
                    c.DVH = (string)r["DVH"];
                }
            }
            return c;
        }

        public int ActualizarStock(BE.Capsula capsula)
        {
            int fa;
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@ID", capsula.ID);
            parametros[1] = new SqlParameter("@STOCK", capsula.Stock);
            parametros[2] = new SqlParameter("@DVH", capsula.DVH);
            parametros[3] = new SqlParameter("@TIPO", "CAPSULA");
            fa = sh.Escribir("ACTUALIZAR_STOCK", parametros);
            return fa;
        }
    }
}
