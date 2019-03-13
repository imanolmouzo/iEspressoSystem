using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Bitacora : System.Web.UI.Page
{
    BLL.Bitacora gestorBitacora = new BLL.Bitacora();
    public List<BE.Bitacora> lsBitacora { get; set; } = new List<BE.Bitacora>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (SEGURIDAD.Sesion._Instance != null)
        {
            if (SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Permiso != "WebMaster")
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

    void Enlazar()
    {
        lsBitacora = gestorBitacora.ListarBitacora();
    }


    protected void ButtonFiltrar_Click(object sender, EventArgs e)
    {
        if(FechaInicio.Value != null && FechaFin.Value != null)
        {
            lsBitacora = gestorBitacora.Filtrar(FechaInicio.Value + " 00:00:00:000", FechaFin.Value + " 23:59:59:998");
        }
    }

    protected void ButtonLimpiar_Click(object sender, EventArgs e)
    {
        Enlazar();
    }
}