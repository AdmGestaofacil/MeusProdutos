using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestaoFacil.AppMvc.Startup))]
namespace GestaoFacil.AppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
