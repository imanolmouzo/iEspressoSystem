using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SEGURIDAD.Sesion._Instance != null)
        {
            BLL.Usuario gestorUsuario = new BLL.Usuario();
            gestorUsuario.Logout();
            Session["ID"] = null;
            Session["Usuario"] = null;
            Session["Password"] = null;
            Session["Pemiso"] = null;
            Session["Estado"] = null;
            Session["DVH"] = null;
        }

    }
}