using Csharpik.Core.Models.BookModels.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Models.BookModels
{
    public class Author
    {
        public Author()
        {

        }

        public Author(AuthorDto dto)
        {
            Name = dto.Name;
            Surname = dto.Surname;
            Biography = dto.Biography;
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

        public ICollection<Book> Books { get; set; }
    }
}
