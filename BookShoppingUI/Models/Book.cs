using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShoppingUI.Models
{
	public class Book
	{
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string BookName { get; set; }
        public string? Image { get; set; }
        //public IFormFile ImageFile { get; set; }
        public double Price { get; set; }
        [MaxLength(20)]
        public string AuthorName { get; set; }
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<CartDetail> CartDetails { get; set; }

    }
}
