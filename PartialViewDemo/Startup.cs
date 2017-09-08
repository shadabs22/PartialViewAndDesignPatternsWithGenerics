using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartialViewDemo.Startup))]
namespace PartialViewDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
