using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualDeckStore.Startup))]
namespace VirtualDeckStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
