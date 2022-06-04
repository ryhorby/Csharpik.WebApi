using Csharpik.Core.Services.Interfaces.CryptoService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Services.CryptoService
{
    public class DecryptorService : IDecryptorService
    {

        private ContentEndingByteKeeper _contentEndingByteKeeper = new();

        public string Decrypt(IFormFile file)
        {
            List<byte> bytes = ReadBytesFromPicture(file);
            List<byte> textBytes = ReadTextByteFromPictureBytes(bytes);

            string text = ReadTextFromBytes(textBytes);

            return text;
        }

        private List<byte> ReadBytesFromPicture(IFormFile file)
        {
            _contentEndingByteKeeper = new ContentEndingByteKeeper(file);

            List<byte> bytes = new List<byte>();

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] fileBytes = ms.ToArray();

                bytes.AddRange(fileBytes);
            }

            return bytes;
        }

        private List<byte> ReadTextByteFromPictureBytes(List<byte> bytes)
        {
            List<byte> textBytes = new List<byte>();

            for (int i = bytes.Count - 1; i >= 0; i--)
            {
                if (bytes[i] == _contentEndingByteKeeper.EndingBytes[1] && bytes[i - 1] == _contentEndingByteKeeper.EndingBytes[0])
                {
                    break;
                }
                else
                {
                    textBytes.Add(bytes[i]);
                }
            }

            return textBytes;
        }

        private static string ReadTextFromBytes(List<byte> textBytes)
        {
            string text = Encoding.ASCII.GetString(textBytes.ToArray());
            text = ReverseString(text);

            return text;
        }

        private static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
