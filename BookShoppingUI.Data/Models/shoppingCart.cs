using System.ComponentModel.DataAnnotations;

namespace BookShoppingUI.Models
{
	public class shoppingCart
	{
		public int Id { get; set; }

		[Required]
		public string UserId { get; set; }
		public bool IDeleted { get; set; } = false;
    }
}
