using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Services.CryptoService
{
    internal class ContentEndingByteKeeper
    {
        private Dictionary<string, int[]> ContentTypesByteEnding = new Dictionary<string, int[]>()
        {
            { "image/jpeg", new int[2] { 255, 217 } },
            { "image/png", new int[2] { 96, 130 } }
        };

        public ContentEndingByteKeeper(IFormFile file)
        {
            foreach (var item in ContentTypesByteEnding)
            {
                if (item.Key == file.ContentType)
                {
                    EndingBytes[0] = item.Value[0];
                    EndingBytes[1] = item.Value[1];
                }
            }

            if (EndingBytes.Length == 0)
            {
                throw new Exception("This content type don`t support now");
            }
        }

        public ContentEndingByteKeeper()
        {

        }

        public int[] EndingBytes { get; private set; } = new int[2];
    }
}
