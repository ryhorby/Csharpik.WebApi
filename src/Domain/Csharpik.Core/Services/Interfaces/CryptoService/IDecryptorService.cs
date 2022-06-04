using Microsoft.AspNetCore.Http;

namespace Csharpik.Core.Services.Interfaces.CryptoService
{
    public interface IDecryptorService
    {
        public string Decrypt(IFormFile file);
    }
}
