using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NhomZuiZeDoAn.Startup))]
namespace NhomZuiZeDoAn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
