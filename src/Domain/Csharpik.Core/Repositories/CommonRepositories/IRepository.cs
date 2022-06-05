using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Repositories.CommonRepositories
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public void Create(T item);
    }
}
