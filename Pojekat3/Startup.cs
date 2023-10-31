using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pojekat3.Startup))]
namespace Pojekat3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
