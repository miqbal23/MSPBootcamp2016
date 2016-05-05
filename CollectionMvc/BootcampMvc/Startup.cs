using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootcampMvc.Startup))]
namespace BootcampMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
