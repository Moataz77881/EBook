﻿using BookShoppingUI.DTOs;
using BookShoppingUI.DTOs.BookDTOs;

namespace BookShoppingUI.services.BookServices
{
    public interface IBookService
    {
        public BookDto CreateBook(BookDto bookDto);
        public List<BookReceivedDto> GetBook(int? id, string? sTem);
        public BookDto UpdateBook(int id, BookDto book);
        public BookDto RemoveBook(int id);

    }
}
