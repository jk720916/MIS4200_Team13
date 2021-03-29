using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS4200_Team13.Startup))]
namespace MIS4200_Team13
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
