using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Penjadwalan.Startup))]
namespace Penjadwalan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
