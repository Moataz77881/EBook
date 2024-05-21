using BookShoppingUI.DTOs;
using BookShoppingUI.DTOs.BookDTOs;
using BookShoppingUI.Models;
using BookShoppingUI.Repository.BookRepo;

namespace BookShoppingUI.services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IBookRepo bookRepo;
        private readonly IWebHostEnvironment environment;

        public BookService(IBookRepo bookRepo, IWebHostEnvironment environment)
        {
            this.bookRepo = bookRepo;
            this.environment = environment;
        }
        public  BookDto CreateBook(BookDto bookDto)
        {
            string? ImagePath = null;
            if (bookDto.UploadImage is not null) 
            {
                ImagePath = environment.WebRootPath + "\\Images\\" + bookDto.UploadImage.FileName;

                using (FileStream stream = System.IO.File.Create(ImagePath))
                {
                    bookDto.UploadImage.CopyTo(stream);
                }
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
    }
}
