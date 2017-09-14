using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trabalho20172.Startup))]
namespace Trabalho20172
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
