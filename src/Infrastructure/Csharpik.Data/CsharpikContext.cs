using Csharpik.Core.Models.BookModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Data
{
    public class CsharpikContext : DbContext
    {
        public CsharpikContext(DbContextOptions<CsharpikContext> options) : base(options)
        {} 

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookFilePassKeeper> PassKeepers { get; set; }
    }
}
