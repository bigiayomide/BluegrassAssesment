using Bluegrass.Menu.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluegrass.Menu.Services
{
	public interface IUserService
    {
		Task<IEnumerable<User>> GetAll();
		Task Create(User user);
		Task Update(User user);
		Task Delete(int id);
		Task<User> GetById(int id);
	}
}
