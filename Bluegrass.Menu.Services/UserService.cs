
using Bluegrass.Menu.EFRepository.Contacts;
using Bluegrass.Menu.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluegrass.Menu.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task Create(User user)
		{
			await _userRepository.Create(user);
		}

		public async Task Delete(int id)
		{
			await _userRepository.Delete(id);
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await _userRepository.GetAll().ToListAsync();
		}

		public async Task<User> GetById(int Id)
		{
			return await _userRepository.GetById(Id);
		}
		public async Task Update(User user)
		{
			await _userRepository.Update(user);
		}
	}
}
