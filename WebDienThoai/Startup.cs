using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDienThoai.Startup))]
namespace WebDienThoai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
