using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmissionManagement.Startup))]
namespace AdmissionManagement
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
