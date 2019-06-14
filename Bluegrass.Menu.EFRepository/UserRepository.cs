using Bluegrass.Menu.EFRepository.Context;
using Bluegrass.Menu.Models;

namespace Bluegrass.Menu.EFRepository.Contacts
{
	public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BluegrassContext context) : base(context) { }
       
    }
}
