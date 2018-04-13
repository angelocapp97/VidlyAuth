using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyAuth.Startup))]
namespace VidlyAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
