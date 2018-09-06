using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBlog3.Startup))]
namespace MyBlog3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
