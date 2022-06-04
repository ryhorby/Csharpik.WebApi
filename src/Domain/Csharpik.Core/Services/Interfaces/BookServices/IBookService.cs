using Csharpik.Core.Models.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Services.Interfaces.BookServices
{
    public interface IBookService<T>
    {
        public IEnumerable<T> GetAll();

        T GetById(int id);
    }
}
