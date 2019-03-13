using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iEspresso.Startup))]
namespace iEspresso
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
