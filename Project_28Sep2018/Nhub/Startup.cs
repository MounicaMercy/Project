using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nhub.Startup))]
namespace Nhub
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
