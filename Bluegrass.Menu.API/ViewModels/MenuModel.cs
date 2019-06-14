using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bluegrass.Menu.API.ViewModels
{
	public class MenuModel
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string Title { get; set; }
		[Required]
		[MaxLength(50)]
		public string Description { get; set; }
		public int? ParentId { get; set; }
		public int? UserId { get; set; }
		[MaxLength(50)]
		public string Icon { get; set; }
	}
}
