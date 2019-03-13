using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Usuario
    {
        SqlHelper sh = new SqlHelper();

        public BE.Usuario Login(BE.Usuario usuario)
        {
            SqlParameter[] parametros = {
            new SqlParameter("@USU", usuario.Username),
            new SqlParameter("@PASS", usuario.Password)
            };
            DataTable tabla = sh.Leer("LOGIN", parametros);
            BE.Usuario usuarioDB = new BE.Usuario();

            if(tabla.Rows.Count == 0)
                usuarioDB = null;
            else
            {
                foreach (DataRow row in tabla.Rows)
                {
                    usuarioDB.ID = (int)row["ID"];
                    usuarioDB.Username = (string)row["USERNAME"];
                    usuarioDB.Password = (string)row["PASSWORD"];
                    usuarioDB.Permiso = (string)row["PERMISO"];
                    usuarioDB.Estado = (int)row["ESTADO"];
                    usuarioDB.DVH = (string)row["DVH"];
                }
            }
            return usuarioDB;
        }

        public List<BE.Usuario> Listar()
        {
            DataTable tabla = sh.Leer("LISTAR_USUARIO", null);
            List<BE.Usuario> ls = new List<BE.Usuario>();
            foreach (DataRow row in tabla.Rows)
                {
                BE.Usuario usuario = new BE.Usuario();
                usuario.ID = (int)row["ID"];
                usuario.Username = (string)row["USERNAME"];
                usuario.Password = (string)row["PASSWORD"];
                usuario.Permiso = (string)row["PERMISO"];
                usuario.Estado = (int)row["ESTADO"];
                usuario.DVH = (string)row["DVH"];
                ls.Add(usuario);
                }
            return ls;
        }

        public int Registrar(BE.Usuario usuario)
        {
            int fa;
            SqlParameter[] parametros = {
            new SqlParameter("@ID", usuario.ID),
            new SqlParameter("@USU", usuario.Username),
            new SqlParameter("@PASS", usuario.Password),
            new SqlParameter("@PER", usuario.Permiso),
            new SqlParameter("@EST", usuario.Estado),
            new SqlParameter("@DVH", usuario.DVH)
            };
            fa = sh.Escribir("REGISTRAR_USUARIO", parametros);
            return fa;
        }
    }
}
