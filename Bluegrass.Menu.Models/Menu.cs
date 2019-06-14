using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bluegrass.Menu.Models
{
	public class Menu : IEntity
	{
		[Key]
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
		public bool Active { get; set; }
		public virtual User User { get; set; }
    public virtual Menu ParentMenu { get; set; }
    public ICollection<Menu> Children { get; set; }
  }
}
