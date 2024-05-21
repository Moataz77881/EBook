using System.ComponentModel.DataAnnotations;

namespace BookShoppingUI.Models
{
	public class CartDetail
	{
		public int Id { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        public Book Book { get; set; }

        public shoppingCart ShoppingCart { get; set; }

    }
}
