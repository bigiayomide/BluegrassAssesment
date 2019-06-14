using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bluegrass.Menu.API.ViewModels
{
	public class MenuViewModel
	{
		public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }
		public int ParentId { get; set; }
		public int? UserId { get; set; }
    [MaxLength(50)]
    public string Icon { get; set; }
    public bool Active { get; set; }
    public IEnumerable<MenuViewModel> Children { get; set; }
    public MenuViewModel ParentMenu { get; set; }   
	}
}
