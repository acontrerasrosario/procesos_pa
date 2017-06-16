using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(procesos_pa.Startup))]
namespace procesos_pa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
