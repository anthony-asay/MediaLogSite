using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaLogSite.Startup))]
namespace MediaLogSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
