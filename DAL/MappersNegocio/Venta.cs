using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Venta
    {
        SqlHelper sh = new SqlHelper();

        public List<BE.Venta> Listar()
        {
            DataTable tabla = sh.Leer("LISTAR_VENTAS", null);
            List<BE.Venta> ls = new List<BE.Venta>();
            foreach (DataRow r in tabla.Rows)
            {
                BE.Venta V = new BE.Venta();
                V.ID = (int)r["ID"];
                V.Cliente.ID = (int)r["ID_CLIENTE"];
                V.Cliente.Username = (string)r["NOMBRE"];
                V.Fecha = (DateTime)r["FECHA"];
                V.Total = Convert.ToSingle((int)r["TOTAL"]);
                ls.Add(V);
            }
            return ls;
        }

        public int Registrar(BE.Venta venta)
        {
            int fa;
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@ID", venta.ID);
            parametros[1] = new SqlParameter("@ID_CLI", venta.Cliente.ID);
            parametros[2] = new SqlParameter("@FECHA", venta.Fecha);
            parametros[3] = new SqlParameter("@TOTAL", venta.Total);
            fa = sh.Escribir("REGISTRAR_VENTA", parametros);
            return fa;
        }

        public void RegistrarVentaDetalle(BE.Venta venta, BE.Producto producto, int cantidad)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@ID_VENTA", venta.ID);
            parametros[1] = new SqlParameter("@PRO", producto.Nombre);
            parametros[2] = new SqlParameter("@CANT", cantidad);
            sh.Escribir("REGISTRAR_VENTA_DETALLE", parametros);
        }
    }
}
