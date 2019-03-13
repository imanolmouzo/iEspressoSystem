using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Bitacora
    {
        SqlHelper sh = new SqlHelper();

        public List<BE.Bitacora> ListarBitacora()
        {
            DataTable tabla = sh.Leer("LISTAR_BITACORA", null);
            List<BE.Bitacora> ls = new List<BE.Bitacora>();
            foreach (DataRow r in tabla.Rows)
            {
                BE.Bitacora b = new BE.Bitacora();
                b.ID = (int)r["ID"];
                b.Fecha = (DateTime)r["FECHA"];
                b.Evento = (string)r["EVENTO"];
                b.Usuario.Username = (string)r["USUARIO"];
                ls.Add(b);
            }
            return ls;
        }

        public int RegistrarBitacora(BE.Bitacora BITACORA)
        {
            int fa;
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@ID", BITACORA.ID);
            parametros[1] = new SqlParameter("@FECHA", BITACORA.Fecha);
            parametros[2] = new SqlParameter("@EVE", BITACORA.Evento);
            parametros[3] = new SqlParameter("@USU", BITACORA.Usuario.Username);
            fa = sh.Escribir("REGISTRAR_BITACORA", parametros);
            return fa;
        }

        public List<BE.Bitacora> FiltrarBitacora(string fecha, string evento, BE.Usuario usuario)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@FECHA", fecha);
            parametros[1] = new SqlParameter("@EVE", evento);
            parametros[2] = new SqlParameter("@USU", usuario.Username);
            DataTable tabla = sh.Leer("FILTRAR_BITACORA", parametros);
            List<BE.Bitacora> ls = new List<BE.Bitacora>();

            if (tabla.Rows.Count == 0)
                ls = null;
            else
                foreach (DataRow r in tabla.Rows)
                {
                    BE.Bitacora b = new BE.Bitacora();
                    b.ID = (int)r["ID"];
                    b.Fecha = (DateTime)r["FECHA"];
                    b.Evento = (string)r["EVENTO"];
                    b.Usuario.Username = (string)r["USUARIO"];
                    ls.Add(b);
                }
            return ls;
        }

        public List<BE.Bitacora> Filtrar(string DESDE, string HASTA)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@DESDE", DESDE);
            parametros[1] = new SqlParameter("@HASTA", HASTA);
            DataTable tabla = sh.Leer("FILTRAR", parametros);
            List<BE.Bitacora> ls = new List<BE.Bitacora>();

            if (tabla.Rows.Count == 0)
                ls = null;
            else
                foreach (DataRow r in tabla.Rows)
                {
                    BE.Bitacora b = new BE.Bitacora();
                    b.ID = (int)r["ID"];
                    b.Fecha = (DateTime)r["FECHA"];
                    b.Evento = (string)r["EVENTO"];
                    b.Usuario.Username = (string)r["USUARIO"];
                    ls.Add(b);
                }
            return ls;
        }
    }
}
