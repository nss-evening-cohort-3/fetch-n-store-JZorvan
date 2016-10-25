using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FetchAndStore.Startup))]
namespace FetchAndStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
