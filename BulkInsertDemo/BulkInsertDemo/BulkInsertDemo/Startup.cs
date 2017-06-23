using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BulkInsertDemo.Startup))]
namespace BulkInsertDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
