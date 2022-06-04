using Csharpik.Core.Services.Interfaces.CryptoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Services.CryptoService
{
    public class EncryptorService : IEncryptorService
    {

        public FileContentResult Encrypt(IFormFile file, string text)
        {

            List<byte> pictureBytes = ReadBytesFromPicture(file);

            List<byte> pictureAndTextBytes = AddTextToPicture(pictureBytes, text);

            FileContentResult contentResult = new FileContentResult(pictureAndTextBytes.ToArray(), file.ContentType);

            return contentResult;
        }

        private List<byte> ReadBytesFromPicture(IFormFile file)
        {
            List<byte> pictureBytes = new List<byte>();

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] fileBytes = ms.ToArray();

                pictureBytes.AddRange(fileBytes);
            }

            return pictureBytes;
        }

        private List<byte> AddTextToPicture(List<byte> pictureBytes, string text)
        {
            byte[] textBytes = Encoding.ASCII.GetBytes(text);

            pictureBytes.AddRange(textBytes);

            return pictureBytes;
        }
    }
}
