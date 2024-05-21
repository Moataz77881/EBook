using System.ComponentModel.DataAnnotations;

namespace BookShoppingUI.Models
{
	public class OrderStatus
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(30)]
        public string StatusName { get; set; }
    }
}
