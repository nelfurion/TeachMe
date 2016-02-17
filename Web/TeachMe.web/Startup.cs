using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeachMe.web.Startup))]
namespace TeachMe.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
