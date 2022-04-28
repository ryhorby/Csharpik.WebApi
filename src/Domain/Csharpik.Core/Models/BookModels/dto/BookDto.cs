using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Models.BookModels.dto
{
    public class BookDto
    {
        public BookDto(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
