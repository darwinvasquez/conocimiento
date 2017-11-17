using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Conocimiento.Startup))]
namespace Conocimiento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
