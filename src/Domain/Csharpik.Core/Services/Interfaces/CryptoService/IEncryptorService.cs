using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Csharpik.Core.Services.Interfaces.CryptoService
{
    public interface IEncryptorService
    {
        public FileContentResult Encrypt(IFormFile file, string text);
    }
}
