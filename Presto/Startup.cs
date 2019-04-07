using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Presto.Startup))]
namespace Presto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
