using BookShoppingUI.DTOs;
using BookShoppingUI.DTOs.BookDTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookShoppingUI.services.BookServices
{
    public interface IBookService
    {
        public BookDto CreateBook(BookDto bookDto);
        public List<BookReceivedDto> GetBook(int? id, string? sTem);
    }
}
