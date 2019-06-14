using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bluegrass.Menu.EFRepository.Contacts;
using Microsoft.EntityFrameworkCore;

namespace Bluegrass.Menu.Services
{
	public class MenuService : IMenuService
  {
    private readonly IMenuRepository _menuRepository;

    public MenuService(IMenuRepository menuRepository)
    {
			_menuRepository = menuRepository;
    }

		public async Task Create(Models.Menu menu)
		{
			await _menuRepository.Create(menu);
		}

		public async Task Delete(int id)
		{
			await _menuRepository.Delete(id);
		}

		public async Task<IEnumerable<Models.Menu>> GetAll()
		{
			return await _menuRepository.GetAll().ToListAsync();
		}

		public async Task<Models.Menu> GetById(int Id)
		{
			var result = await _menuRepository.GetById(Id);
		
			result.Children = await BuildCascadingNodes(Id);
      return result;
		}
		public async Task Update(Models.Menu menu)
		{
			 await _menuRepository.Update(menu);
		}

		private async Task<ICollection<Models.Menu>> BuildCascadingNodes(int parentId)
		{
			var childNodes = await _menuRepository.GetChildMenus(parentId);
			foreach (var menuitem in childNodes)
			{
				if (menuitem.ParentId != 0 && menuitem.ParentId != null)
				{
					menuitem.Children = await BuildCascadingNodes(menuitem.Id);
				}
			}
			return childNodes;
		}
	}
}
