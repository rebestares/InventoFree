using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inventofree.Startup))]
namespace Inventofree
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
