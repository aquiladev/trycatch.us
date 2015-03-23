using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using trycatch.Data;
using trycatch.Domain;
using trycatch.Services.Interfaces;

namespace trycatch.web
{
	public class InjectorInitializer
	{
		public static Container Initialize(IAppBuilder app)
		{
			var container = CreateContainer(app);
			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

			return container;
		}

		public static Container CreateContainer(IAppBuilder app)
		{
			var container = new Container();

			container.RegisterSingle(app);

			container.Register<IDbContext, DataContext>();
			container.Register<IRepository<Article>, Repository<Article>>();
			RegisterNamespace(container, typeof(IArticleService).Assembly, "trycatch.Services");

			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			container.RegisterMvcIntegratedFilterProvider();

			return container;
		}

		public static void RegisterNamespace(Container container, Assembly assembly, string regnamespace)
		{
			var registrations =
				from t in assembly.GetExportedTypes()
				where t.Namespace == regnamespace
				where t.GetInterfaces().Any()
				select new { Service = t.GetInterfaces().Single(), Implementation = t };

			foreach (var reg in registrations)
			{
				container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
			}
		}
	}
}