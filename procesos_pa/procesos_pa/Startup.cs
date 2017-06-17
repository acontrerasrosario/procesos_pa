using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PROCESOS_PA.Startup))]
namespace PROCESOS_PA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
