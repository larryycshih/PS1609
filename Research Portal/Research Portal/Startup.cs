using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Research_Portal.Startup))]
namespace Research_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
