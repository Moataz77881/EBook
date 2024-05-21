using BookShopping.Business;
using BookShopping.Business.services.ConvertFiles;
using BookShoppingUI.DTOs;
using BookShoppingUI.DTOs.BookDTOs;
using BookShoppingUI.Models;
using BookShoppingUI.Repository.BookRepo;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;

namespace BookShoppingUI.services.BookServices
{
    public class BookService : IBookService
    {
        private string? ImagePath = null;
        private readonly IBookRepo bookRepo;
        private readonly IConvertFile convert;

        public BookService(IBookRepo bookRepo,IConvertFile convert)
        {
            this.bookRepo = bookRepo;
            this.convert = convert;
        }

        public  BookDto CreateBook(BookDto bookDto)
        {


            if (bookDto.UploadImage is not null) 
            {
                ImagePath = convert.convert(bookDto.UploadImage);   
            }

            //map book model to book dto
            var bookModel = new Book
            {
                BookName = bookDto.BookName,
                Price = bookDto.Price,
                GenreId = bookDto.GenreId,
                AuthorName = bookDto.AuthorName,
                Image = ImagePath
                
            };
            //call create book in repository method
            var bookCreated = bookRepo.CreateBookRepo(bookModel);
            
            var Dto = new BookDto
            {
                BookName = bookCreated.BookName,
                Price = bookCreated.Price,
                GenreId= bookCreated.GenreId,
                AuthorName = bookCreated.AuthorName,
            };
            return Dto;

        }

        public List<BookReceivedDto> GetBook(int? id, string? sTem)
        {

            var model = bookRepo.GetBookRepo(id,sTem);
            

            List<BookReceivedDto> dto = new List<BookReceivedDto>();
            int length;
            string? ImageName = null;
            foreach (var element in model)
            {

                if (!string.IsNullOrEmpty(element.Image))
                {
                    int s = "Images\\".Length;
                    length = element.Image.LastIndexOf("Images\\");
                    ImageName = element.Image.Substring(s + length);
                }
                dto.Add(
                    new BookReceivedDto
                    {
                        id=element.Id,
                        BookName = element.BookName,
                        Image = ImageName,
                        Price = element.Price,
                        AuthorName = element.AuthorName,
                        Genre = new DTOs.GenreDTOs.GenreDto
                        {
                            GenreName = element.Genre.GenreName
                        },
                    }
                    );
            }
            return dto;
        }

        public BookDto UpdateBook(int id, BookDto book)
        {

            //map book dtoto book model
            if (book.UploadImage is not null) 
            {

                ImagePath = convert.convert(book.UploadImage);

            }
            var model = new Book
            {
                BookName = book.BookName,
                Price = book.Price,
                AuthorName = book.AuthorName,
                GenreId = book.GenreId,
                Image = ImagePath
            };
            var bookUpdated = bookRepo.UpdateBook(id, model);
            //map model to BookDto

            var dto = new BookDto
            {
                BookName = bookUpdated.BookName,
                Price = bookUpdated.Price,
                AuthorName = bookUpdated.AuthorName,

            };
            return dto;
        }

        public BookDto RemoveBook(int id)
        {
            var bookRemoved = bookRepo.RemoveBook(id);
            var dto = new BookDto
            {
                AuthorName = bookRemoved.AuthorName,
                BookName = bookRemoved.AuthorName,
                GenreId= bookRemoved.GenreId,
                Price= bookRemoved.Price,
            };
            return dto;

        }
    }
}
