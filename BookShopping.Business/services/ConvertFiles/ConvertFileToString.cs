using BookShoppingUI.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping.Business.services.ConvertFiles
{
    public class ConvertFileToString : IConvertFile
    {
        private readonly IWebHostEnvironment environment;

        public ConvertFileToString(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        public string convert(IFormFile? ImageFile)
        {
            string ImagePath = environment.WebRootPath + "\\Images\\" + ImageFile.FileName;

            using (FileStream stream = File.Create(ImagePath))
            {
                ImageFile.CopyTo(stream);
            }
            return ImagePath;
        }
    }
}
