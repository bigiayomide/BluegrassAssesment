using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bluegrass.Menu.Models
{
  public class User : IEntity
  {
    /// <summary>
    /// basic user details
    /// </summary>
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [MaxLength(50)]
    public string Email { get; set; }
    public bool Active { get; set; }
    public ICollection<Menu> Menu { get; set; }
  }
}