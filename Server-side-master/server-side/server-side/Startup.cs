using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(server_side.Startup))]
namespace server_side
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
