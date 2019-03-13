using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vistas_Restore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SEGURIDAD.Sesion._Instance != null)
        {
            if (SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Permiso != "WebMaster")
            {
                Response.Write(@"<script language='javascript'>alert('No tiene permiso para ingresar a esta pagina.')</script>");
                Response.Write("<script language=javascript> history.back(); </script>");
            }
        }
        else
            Response.Redirect("~/Account/Login");
    }

    protected void ButtonRestaurar(object sender, EventArgs e)
    {
        SEGURIDAD.Backup gestorBackup = new SEGURIDAD.Backup();
        string mensaje = gestorBackup.Restaurar(Server.MapPath("~/BackupDB//" + FileUpload1.FileName));
        BLL.Bitacora gestorBitacora = new BLL.Bitacora();
        BE.Bitacora bitacora = new BE.Bitacora();
        bitacora.Fecha = DateTime.Now;
        bitacora.Evento = mensaje;
        bitacora.Usuario = SEGURIDAD.Sesion._Instance.UsuarioEnSesion;
        gestorBitacora.RegistrarBitacora(bitacora);
        Response.Write(@"<script language='javascript'>alert('" + mensaje + "')</script>");
        Response.Redirect("~/Inicio");
    }
}