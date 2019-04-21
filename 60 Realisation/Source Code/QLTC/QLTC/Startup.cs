using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLTC.Startup))]
namespace QLTC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
