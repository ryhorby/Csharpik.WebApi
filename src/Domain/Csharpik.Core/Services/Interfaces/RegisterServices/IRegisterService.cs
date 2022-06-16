using Csharpik.Core.Models.User;
using Csharpik.Core.Models.User.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Services.Interfaces.RegisterServices
{
    public interface IRegisterService
    {
        public IEnumerable<UserDto> GetAll();

        UserDto GetById(int id);

        void Create(UserDto dto);

        UserDto Update(UserDto dto);

        void Delete(int id);

        string Login(UserDto dto)
    }
}
