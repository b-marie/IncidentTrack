using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IncidentTrack.Startup))]
namespace IncidentTrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
