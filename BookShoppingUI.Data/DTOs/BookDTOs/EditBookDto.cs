using BookShoppingUI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShoppingUI.Data.DTOs.BookDTOs
{
	public class EditBookDto
	{
        public int id { get; set; }
        public  BookDto bookDto{ get; set; }
    }
}
