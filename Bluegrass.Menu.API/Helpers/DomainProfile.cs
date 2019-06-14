using AutoMapper;
using Bluegrass.Menu.API.ViewModels;
using Bluegrass.Menu.Models;

namespace Bluegrass.Menu.API.Helpers
{
	public class DomainProfile : Profile
	{

		public DomainProfile()
		{
      
			CreateMap<MenuModel, Models.Menu>()
        .ForMember(x => x.Active, opt => opt.MapFrom(x => true));

      CreateMap<Models.Menu, MenuViewModel>();        

      CreateMap<UserViewModel, User>()
        .ForMember(x => x.Active, opt => opt.MapFrom(x => true));
    
    }
  }
}
