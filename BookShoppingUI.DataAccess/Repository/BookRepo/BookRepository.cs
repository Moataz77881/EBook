using BookShoppingUI.Data;
using BookShoppingUI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingUI.Repository.BookRepo
{
    public class BookRepository : IBookRepo
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Book CreateBookRepo(Book book)
        {
            context.Book.Add(book);
            context.SaveChanges();
            return book;
        }

        public List<Book> GetBookRepo(int? id, string? sTem)
        {
            var book = context.Book
                .Include(x => x.Genre).AsSplitQuery().ToList();
                

            if (sTem is not null)
            {
                book = book.Where(x => x.BookName.ToLower().StartsWith(sTem.ToLower())).ToList();
            }
            if (id is not null) 
            {
                book = book.Where(x=>x.Genre.Id == id).ToList();
            }
            return book;
                
        }

        public Book? RemoveBook(int BookId)
        {
            var book = context.Book.FirstOrDefault(x => x.Id == BookId);
            if (book is not null) 
            {
                context.Book.Remove(book);
                context.SaveChanges();
            }
            return book;
        }

        public Book? UpdateBook(int BookId, Book book)
        {
            var Model = context.Book.FirstOrDefault(x=>x.Id == BookId);
            if (Model is not null) 
            {
                Model.BookName = book.BookName;
                Model.AuthorName = book.AuthorName;
                Model.Price = book.Price;
                Model.GenreId = book.GenreId;
                Model.Image = book.Image;
                context.SaveChanges();
                return Model;
            }
            return null;

        }
    }
}
