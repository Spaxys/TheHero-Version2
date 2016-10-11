using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hero2.Startup))]
namespace hero2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
