using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jspBlog.Startup))]
namespace jspBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
