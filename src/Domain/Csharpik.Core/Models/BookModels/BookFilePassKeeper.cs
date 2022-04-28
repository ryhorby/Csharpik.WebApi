using Csharpik.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Models.BookModels
{
    public class BookFilePassKeeper : ICsharpikDtoObject
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string PdfFileName { get; set; }

        [Required]
        [MaxLength(50)]
        public string PictureFileName { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
