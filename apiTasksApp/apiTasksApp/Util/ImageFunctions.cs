using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace apiTasksApp.Util
{
    public class ImageFunctions
    {
        public static byte[] ToBytes(IFormFile image)
        {
            using MemoryStream ms = new MemoryStream();
            image.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
