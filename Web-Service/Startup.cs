using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Service.Startup))]
namespace Web_Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
