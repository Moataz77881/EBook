using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BookShoppingUI.Models
{
	public class OrderDetail
	{
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public Book Book { get; set; }
        public Order Order { get; set; }

    }
}
