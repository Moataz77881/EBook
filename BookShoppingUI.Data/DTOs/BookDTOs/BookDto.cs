using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookShoppingUI.DTOs
{
    public class BookDto
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public IFormFile? UploadImage { get; set; }


        //public string? Image { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
