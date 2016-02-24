using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(TeachMe.Web.Startup))]

namespace TeachMe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
