using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Notepad.Startup))]
namespace Notepad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
