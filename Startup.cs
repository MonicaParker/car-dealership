using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealershipApplication.Startup))]
namespace CarDealershipApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
