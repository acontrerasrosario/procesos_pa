using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(procesos_app.Startup))]
namespace procesos_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
