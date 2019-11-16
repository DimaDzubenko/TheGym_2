using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheGym_2.Startup))]
namespace TheGym_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
