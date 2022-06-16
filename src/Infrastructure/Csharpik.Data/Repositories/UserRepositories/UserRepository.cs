using Csharpik.Core.Models.User;
using Csharpik.Core.Repositories.CommonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Data.Repositories.UserRepositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly CsharpikContext _context;

        public UserRepository(CsharpikContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Single(u => u.Id == id);
        }

        public void Create(User item)
        {
            //HACK: Check already exist or not

            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public User Update(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
