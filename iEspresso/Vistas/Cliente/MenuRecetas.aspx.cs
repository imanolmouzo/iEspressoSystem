using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_MenuRecetas : System.Web.UI.Page
{
    BLL.Receta gestorReceta = new BLL.Receta();

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
        if (SEGURIDAD.TechnicalController.PageCounterMenuRecetas > 0)
        {
            try
            {
                int id = 0;
                id = int.Parse(Request.QueryString["ID_Receta"]);
                BE.Receta receta = new BE.Receta();
                receta = gestorReceta.Obtener(id);

                if (receta != null) { SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Carrito.lsProductos.Add(receta); }
            }
            catch (Exception) { }
        }
        else
        {
            SEGURIDAD.TechnicalController.lsRecetas = gestorReceta.ListarDisponibles();
            SEGURIDAD.TechnicalController.PageCounterMenuRecetas++;
        }
    }
}