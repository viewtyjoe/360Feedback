using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_360Feedback.Startup))]
namespace _360Feedback
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
