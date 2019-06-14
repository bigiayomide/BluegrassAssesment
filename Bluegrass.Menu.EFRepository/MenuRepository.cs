using Microsoft.EntityFrameworkCore;
using Bluegrass.Menu.EFRepository.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Bluegrass.Menu.EFRepository.Contacts
{
	public class MenuRepository : GenericRepository<Models.Menu>, IMenuRepository
	{
		private readonly DbContextOptions<BluegrassContext> _options;
		public MenuRepository(BluegrassContext context, DbContextOptions<BluegrassContext> options) : base(context) { _options = options;  }

		public async Task<ICollection<Models.Menu>> GetChildMenus(int parentId)
		{
			using (var context = new BluegrassContext(_options))
			{
				return await context.Menu.Where(x=>x.ParentId == parentId).ToListAsync();
			}
		}
	}
}
