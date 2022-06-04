using Csharpik.Core.Services.Interfaces.CryptoService;
using Microsoft.AspNetCore.Mvc;

namespace Csharpik.WebApi.Controllers.CryptoProject
{
    [ApiController]
    [Route("Crypto")]
    public class CryptoController : Controller
    {
        private readonly IEncryptorService _encryptor;
        private readonly IDecryptorService _decryptor;

        public CryptoController(IEncryptorService encryptor, IDecryptorService decryptor)
        {
            _encryptor = encryptor;
            _decryptor = decryptor;
        }

        [HttpPost("Encrypt")]
        public FileContentResult Encrypt(IFormFile file, string text)
        {
            return _encryptor.Encrypt(file, text);
        }

        [HttpPost("Decrypt")]
        public IActionResult Decrypt(IFormFile file)
        {
            return Ok(_decryptor.Decrypt(file));
        }
    }
}
