using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Csharpik.Core.Models.BookModels.dto
{
    public class BookDto
    {
        public BookDto()
        {

        }

        public BookDto(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Description = book.Description;
            IsFree = book.IsFree;
            AuthorsId = new List<int>();

            if (book.Authors != null && book.Authors.Count != 0)
            {
                foreach (Author author in book.Authors)
                {
                    AuthorsId.Add(author.Id);
                }
            }
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

        public ICollection<int> AuthorsId { get; set; }
    }
}
