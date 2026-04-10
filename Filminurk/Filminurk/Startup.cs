using Owin;
using Microsoft.Owin;
using Microsoft.AspNetCore.SignalR;

[assembly: OwinStartup(typeof(Filminurk.Startup))]

namespace Filminurk
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}