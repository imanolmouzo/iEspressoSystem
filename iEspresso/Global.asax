<%@ Application Language="C#" %>
<%@ Import Namespace="iEspresso" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<Script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        //BLL.DVV gestorDVV = new BLL.DVV();
        //gestorDVV.VerificarIntegridad();

        //BLL.DVH gestorDVH = new BLL.DVH();
        //gestorDVH.VerificarIntegridad();
    }

</script>
