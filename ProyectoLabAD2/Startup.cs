using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoLabAD2.Startup))]
namespace ProyectoLabAD2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
