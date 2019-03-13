using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_MenuCapsulas : System.Web.UI.Page
{
    BLL.Capsula gestorCapsula = new BLL.Capsula();

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
                Enlazar();           
        }
        else
            Response.Redirect("~/Account/Login");
    }

    public void Enlazar()
    { 
        if (SEGURIDAD.TechnicalController.PageCounterMenuCapsulas > 0)
        {
            try
            {
                int id = 0;
                id = int.Parse(Request.QueryString["ID_Capsula"]);
                BE.Capsula capsula = new BE.Capsula();
                capsula = gestorCapsula.Obtener(id);

                if (capsula != null) { SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos.Add(capsula); }
            }
            catch (Exception) { }
        }
        else
        {
            SEGURIDAD.TechnicalController.lsCapsulas = gestorCapsula.Listar();
            SEGURIDAD.TechnicalController.PageCounterMenuCapsulas++;
        } 
    }

}