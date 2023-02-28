using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HManAPI.Startup))]
namespace HManAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
