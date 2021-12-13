using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoneMyHair.Startup))]
namespace DoneMyHair
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
