using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeanStore.Startup))]
namespace BeanStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
