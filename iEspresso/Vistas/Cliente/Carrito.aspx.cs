using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Cliente_Carrito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SEGURIDAD.Sesion._Instance != null)
        {
            if (SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Permiso != "Cliente")
            {
                Response.Write(@"<script language='javascript'>alert('No tiene permiso para ingresar a esta pagina.')</script>");
                Response.Write("<script language=javascript> history.back(); </script>");
            }
            else
            {
                SEGURIDAD.TechnicalController.New();
                Enlazar();
                SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.Total = 0;
                foreach (BE.Producto P in SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos)
                {
                    if (P.GetType() == typeof(BE.Capsula))
                        SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.Total += (P.Precio * 10);
                    else
                        SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.Total += P.Precio;
                }
                LabelT.Text = "Total: " + SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.Total.ToString("c");
            }
                
        }
        else
            Response.Redirect("~/Account/Login");
    }

    public void Enlazar()
    {
        try
        {
            int id = 0;
            id = int.Parse(Request.QueryString["ID_Producto"]);
            foreach (BE.Producto P in SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos)
            {
                if (P.ID == id)
                    SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos.Remove(P);
            }
        }
        catch (Exception) { }
    }

    protected void ButtonConfirmar_Click(object sender, EventArgs e)
    {
        if (SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos.Count > 0)
        {
            BLL.Venta gestorVenta = new BLL.Venta();
            gestorVenta.Registrar();
            Response.Redirect("~/Vistas/Cliente/Cliente.aspx");
        }
    }
}