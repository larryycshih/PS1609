using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WSU_Scholar.Startup))]
namespace WSU_Scholar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
