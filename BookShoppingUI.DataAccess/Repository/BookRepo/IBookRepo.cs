using BookShoppingUI.Models;

namespace BookShoppingUI.Repository.BookRepo
{
    public interface IBookRepo
    {
        public Book CreateBookRepo(Book book);
        public List<Book> GetBookRepo(int? id, string? sTem);
        public Book? UpdateBook(int BookId, Book book);
        public Book? RemoveBook(int BookId);

    }
}
