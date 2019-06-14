using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluegrass.Menu.Services
{
	public interface IMenuService
  {
    Task<IEnumerable<Models.Menu>> GetAll();
    Task Create(Models.Menu menu);
    Task Update(Models.Menu menu);
    Task Delete(int id);
    Task<Models.Menu> GetById(int id);
  }
}
