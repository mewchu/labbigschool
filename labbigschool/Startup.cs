using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(labbigschool.Startup))]
namespace labbigschool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
