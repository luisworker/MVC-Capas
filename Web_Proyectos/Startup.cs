using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Proyectos.Startup))]
namespace Web_Proyectos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
