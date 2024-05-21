using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping.Business.services.ConvertFiles
{
    public interface IConvertFile
    {
        public string convert(IFormFile? ImageFile);

    }
}
