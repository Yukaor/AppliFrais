using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppliFrais.Startup))]
namespace AppliFrais
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
