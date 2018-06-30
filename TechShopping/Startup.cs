using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechShopping.Startup))]
namespace TechShopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
