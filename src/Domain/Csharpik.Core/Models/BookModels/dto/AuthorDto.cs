using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Models.BookModels.dto
{
    public class AuthorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public List<int> BooksIdList { get; set; }
    }
}
