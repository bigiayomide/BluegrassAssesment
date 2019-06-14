using Microsoft.Extensions.DependencyInjection;
using Bluegrass.Menu.API.Helpers;
using Bluegrass.Menu.API.Helpers.Contracts;
using Bluegrass.Menu.EFRepository.Contacts;
using Bluegrass.Menu.Services;

namespace Bluegrass.Menu.API.Extensions
{
	public static class DIServiceExtension
	{
		public static void AddDIServices(this IServiceCollection services)
		{
			services.AddTransient<IMenuService, MenuService>();
			services.AddTransient<IMenuRepository, MenuRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IActionResponseHelper, ActionResponseHelper>();
		}
	}
}
