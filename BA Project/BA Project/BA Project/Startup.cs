using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BA_Project.Startup))]
namespace BA_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
