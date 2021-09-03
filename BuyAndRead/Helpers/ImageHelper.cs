using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BuyAndRead.Helpers

// ImageHelper helps to download pics in dbs with guid-format 

{
    public class ImageHelper
    {
        public static Guid? UploadImage(IFormFile imageData)
        {
            Guid? result = null;
            if (imageData != null)
            {
                result = Guid.NewGuid();
                var fileName = $"{result}.jpg";

                var filePath = Path.Combine("wwwroot/img/Uploads", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageData.CopyTo(fileStream);
                } 
            }
            return result;
        }

        public static string GetUrl(Guid? guid)
        {
            if (!guid.HasValue || guid.Value == Guid.Empty)
            {
                return null;
            }
            return string.Format("~/img/Uploads/{0}.jpg", guid);
        }
    }
}