using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluegrass.Menu.EFRepository.Contacts
{
	public interface IMenuRepository : IGenericRepository<Models.Menu>
	{
		Task<ICollection<Models.Menu>> GetChildMenus(int parentId);
	}
}
