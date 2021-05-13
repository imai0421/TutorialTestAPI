using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

[assembly: OwinStartupAttribute(typeof(TutorialTestAPI.Startup))]
namespace TutorialTestAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            GlobalHost.TraceManager.Switch.Level = SourceLevels.Information;
        }
    }
}
