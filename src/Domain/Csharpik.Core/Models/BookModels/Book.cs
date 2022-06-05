using Csharpik.Core.Models.BookModels.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Models.BookModels
{
    public class Book
    {
        public Book()
        {

        }

        public Book(BookDto dto)
        {
            Title = dto.Title;
            Description = dto.Description;
            IsFree = dto.IsFree;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public bool IsFree { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
