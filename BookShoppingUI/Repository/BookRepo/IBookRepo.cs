using BookShoppingUI.Models;

namespace BookShoppingUI.Repository.BookRepo
{
    public interface IBookRepo
    {
        public Book CreateBookRepo(Book book);
        public List<Book> GetBookRepo(int? id, string? sTem);

    }
}
