using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Cliente : System.Web.UI.Page
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
        }
        else
            Response.Redirect("~/Account/Login");
    }
}