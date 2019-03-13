using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using iEspresso;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        UserName.Focus();
    }

    protected void LogIn(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(UserName.Text) && !string.IsNullOrWhiteSpace(Password.Text))
        {
            BLL.Usuario gestorUsuario = new BLL.Usuario();
            BE.Usuario UsuarioIngresado = new BE.Usuario();
            UsuarioIngresado.Username = UserName.Text;
            UsuarioIngresado.Password = Password.Text;
            gestorUsuario.Login(UsuarioIngresado);
            gestorUsuario.Informar += InformarMsg;
            if (SEGURIDAD.Sesion._Instance != null)
            {
                Session["ID"] = SEGURIDAD.Sesion._Instance.UsuarioEnSesion.ID;
                Session["Usuario"] = SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Username;
                Session["Password"] = SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Password;
                Session["Pemiso"] = SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Permiso;
                Session["Estado"] = SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Estado;
                Session["DVH"] = SEGURIDAD.Sesion._Instance.UsuarioEnSesion.DVH;
                SEGURIDAD.Sesion.Intentos = 0;
                Redirigir();
            }
            else
            {
                SEGURIDAD.Sesion.Intentos++;

                if (SEGURIDAD.Sesion.Intentos == 3)
                {
                    UserName.Enabled = false;
                    Password.Enabled = false;
                }
                InformarMsg("Usuario y/o contraseña incorrectos");
            }
        }
        else
            ErrorMessage.Visible = true;

    }

    void Redirigir()
    {
        if (SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Permiso == "WebMaster")
            Response.Redirect("~/Vistas/WebMaster/WebMaster.aspx");
        if (SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Permiso == "Cliente")
            Response.Redirect("~/Vistas/Cliente/Cliente.aspx");
        if(SEGURIDAD.Sesion._Instance.UsuarioEnSesion.Permiso=="Barista")
            Response.Redirect("~/Vistas/Barista/Barista.aspx");
    }

    private void InformarMsg(string mensaje)
    {
        Response.Write(@"<script language='javascript'>alert('" + mensaje + "')</script>");
    }
}