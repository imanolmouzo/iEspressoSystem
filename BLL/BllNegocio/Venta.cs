using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Venta
    {
        DAL.Venta mp = new DAL.Venta();

        public List<BE.Venta> Listar() { return mp.Listar(); }

        public void Registrar()
        {
            try
            {
                BE.Venta VENTA = new BE.Venta();
                VENTA.ID = DAL.MapperID.ObtenerNuevoID("VENTA");
                VENTA.Cliente = SEGURIDAD.Sesion._Instance.UsuarioEnSesion;
                VENTA.Fecha = DateTime.Now;
                VENTA.Total = SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.Total;
                int r = mp.Registrar(VENTA);
                if (r == 1)
                {
                    List<BE.Producto> ls = SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos;
                    foreach (BE.Producto Producto in SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos)
                    {
                        int cantidad = 0;
                        List<BE.Producto> lsOk = new List<BE.Producto>();
                        foreach (BE.Producto Prod in ls)
                        {
                            if (Producto.ID == Prod.ID && Producto.Nombre == Prod.Nombre) { cantidad++; }
                            else { lsOk.Add(Prod); }
                        }
                        if (cantidad > 0) { mp.RegistrarVentaDetalle(VENTA, Producto, cantidad); }
                        ls = lsOk;
                    }
                    SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito = new BE.Carrito();
                }
            }
            catch (Exception ex) { }
        }
    }
}
