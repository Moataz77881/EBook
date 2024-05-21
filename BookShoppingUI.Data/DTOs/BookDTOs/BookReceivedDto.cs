using BookShoppingUI.DTOs.GenreDTOs;
using BookShoppingUI.Models;

namespace BookShoppingUI.DTOs.BookDTOs
{
    public class BookReceivedDto
    {
        public int id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public GenreDto Genre { get; set; }

    }
}
