using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trycatch.web.Startup))]
namespace trycatch.web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			InjectorInitializer.Initialize(app);
			//ConfigureAuth(app);
		}
	}
}
