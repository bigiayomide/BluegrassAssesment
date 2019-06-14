using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bluegrass.Menu.API.ViewModels
{
	public class UserViewModel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string Username { get; set; }
		[Required]
		[MaxLength(50)]
		public string Email { get; set; }
	}
}
