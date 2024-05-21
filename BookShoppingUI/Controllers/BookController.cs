using BookShoppingUI.DTOs;
using BookShoppingUI.services.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppingUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService) 
        {
            this.bookService = bookService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/createbook")]
        public IActionResult CreateBook(BookDto bookDto)
        {
            var bookCreated = bookService.CreateBook(bookDto);
            return Ok(bookCreated);
        }

        [HttpGet("/book")]
        public IActionResult GetBooks([FromQuery] int? FilterByGenreId,[FromQuery]string? FilterByBookName) 
        {
            var res = bookService.GetBook(FilterByGenreId,FilterByBookName);
            
            return Ok(res);
        }
    }
}
