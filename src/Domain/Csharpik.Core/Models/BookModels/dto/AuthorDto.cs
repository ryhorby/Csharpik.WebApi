using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Models.BookModels.dto
{
    public class AuthorDto
    {
        public AuthorDto()
        {

        }

        public AuthorDto(Author author)
        {
            Id = author.Id;
            Name = author.Name;
            Surname = author.Surname;
            Biography = author.Biography;
            BooksId = new List<int>();

            if (author.Books != null && author.Books.Count != 0)
            {
                foreach (Book book in author.Books)
                {
                    BooksId.Add(book.Id);
                }
            }
        }


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Biography { get; set; }

        public ICollection<int> BooksId { get; set; }

    }
}
