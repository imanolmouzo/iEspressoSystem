using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Receta
    {
        SqlHelper sh = new SqlHelper();

        public List<BE.Receta> Listar(string tipo)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@TIPO", tipo);
            DataTable tabla = sh.Leer("LISTAR_RECETAS", parametro);
            List<BE.Receta> ls = new List<BE.Receta>();

            foreach (DataRow r in tabla.Rows)
            {
                BE.Receta Receta = new BE.Receta();
                Receta.ID = (int)r["ID"];
                Receta.Nombre = (string)r["NOMBRE"];
                Receta.Descripcion = (string)r["DESCRIPCION"];
                Receta.Capsula.ID = (int)r["ID_CAPSULA"];
                Receta.Capsula.Nombre = (string)r["NOMBRE_CAP"];
                Receta.Capsula.Intensidad = (int)r["INTEN_CAP"];
                Receta.Capsula.Descripcion = (string)r["DESC_CAP"];
                Receta.Capsula.Tipo = (string)r["TIPO_CAP"];
                Receta.Capsula.Precio = Convert.ToSingle(r["PRECIO_CAP"]);
                Receta.Capsula.Stock = (int)r["STOCK_CAP"];
                Receta.Dificultad = (string)r["DIFICULTAD"];
                Receta.TiempoPreparacion = (string)r["TIEMPO_PREPARACION"];
                Receta.Precio = Convert.ToSingle(r["PRECIO"]);
                Receta.Estado = (int)r["ESTADO"];
                Receta.DVH = (string)r["DVH"];
                Receta.Ingredientes = ListarDetalleRecetaIngrediente(Receta);
                ls.Add(Receta);
            }
            return ls;
        }

        public List<BE.Ingrediente> ListarDetalleRecetaIngrediente(BE.Receta receta)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID_RECETA", receta.ID);
            DataTable tabla = sh.Leer("LISTAR_DETALLE_RECETA_INGREDIENTE", parametros);
            List<BE.Ingrediente> ls = new List<BE.Ingrediente>();

            foreach (DataRow r in tabla.Rows)
            {
                BE.Ingrediente I = new BE.Ingrediente();
                I.ID = (int)r["ID_INGREDIENTE"];
                I.Nombre = (string)r["NOMBRE"];
                I.Cantidad = Convert.ToSingle(r["CANTIDAD"]);
                ls.Add(I);
            }
            return ls;
        }

        public BE.Receta Obtener(int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@ID", id);
            DataTable tabla = sh.Leer("OBTENER_RECETA", parametro);
            BE.Receta Receta = new BE.Receta();

            if (tabla.Rows.Count == 0)
                Receta = null;
            else
            {
                foreach (DataRow r in tabla.Rows)
                {
                    Receta.ID = (int)r["ID"];
                    Receta.Nombre = (string)r["NOMBRE"];
                    Receta.Descripcion = (string)r["DESCRIPCION"];
                    Receta.Capsula.ID = (int)r["ID_CAPSULA"];
                    Receta.Capsula.Nombre = (string)r["NOMBRE_CAP"];
                    Receta.Capsula.Intensidad = (int)r["INTEN_CAP"];
                    Receta.Capsula.Descripcion = (string)r["DESC_CAP"];
                    Receta.Capsula.Tipo = (string)r["TIPO_CAP"];
                    Receta.Capsula.Precio = Convert.ToSingle(r["PRECIO_CAP"]);
                    Receta.Capsula.Stock = (int)r["STOCK_CAP"];
                    Receta.Dificultad = (string)r["DIFICULTAD"];
                    Receta.TiempoPreparacion = (string)r["TIEMPO_PREPARACION"];
                    Receta.Precio = Convert.ToSingle(r["PRECIO"]);
                    Receta.Estado = (int)r["ESTADO"];
                    Receta.DVH = (string)r["DVH"];
                    Receta.Ingredientes = ListarDetalleRecetaIngrediente(Receta);
                }
            }
            return Receta;
        }
    }
}
