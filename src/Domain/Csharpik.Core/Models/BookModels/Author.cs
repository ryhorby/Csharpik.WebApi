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
