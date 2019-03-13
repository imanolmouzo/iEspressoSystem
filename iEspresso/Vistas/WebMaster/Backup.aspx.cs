using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Vistas_Backup : System.Web.UI.Page
{
    public List<string> lsBackup { get; set; } = new List<string>();

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

    protected void ButtonBackup(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtBackupName.Text))
        {
            SEGURIDAD.Backup gestorBackup = new SEGURIDAD.Backup();
            string mensaje = gestorBackup.RealizarBackup(Server.MapPath("~/BackupDB/") + txtBackupName.Text);
            BLL.Bitacora gestorBitacora = new BLL.Bitacora();
            BE.Bitacora bitacora = new BE.Bitacora();
            bitacora.Fecha = DateTime.Now;
            bitacora.Evento = mensaje;
            bitacora.Usuario = SEGURIDAD.Sesion._Instance.UsuarioEnSesion;
            gestorBitacora.RegistrarBitacora(bitacora);
            Enlazar();
            txtBackupName.Text = "";
        }
        else
            ErrorMessage.Visible = true;
    }

    public void Enlazar()
    {
        lsBackup = new List<string>();
        DirectoryInfo DI = new DirectoryInfo(@Server.MapPath("~/BackupDB/"));
        foreach (var archivo in DI.GetFiles())
            lsBackup.Add(archivo.Name);
    }
}