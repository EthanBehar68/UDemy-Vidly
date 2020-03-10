using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UDemyVidly.App_Start.Startup))]
namespace UDemyVidly.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
