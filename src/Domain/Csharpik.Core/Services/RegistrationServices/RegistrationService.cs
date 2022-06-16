using Csharpik.Core.Models.User;
using Csharpik.Core.Models.User.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Csharpik.Core.Services.Interfaces.RegisterServices;
using Csharpik.Core.Repositories.CommonRepositories;

namespace Csharpik.Core.Services.RegistrationServices
{
    public class RegistrationService : IRegisterService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _repository;

        public RegistrationService(IConfiguration configuration, IRepository<User> repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public IEnumerable<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto GetById(int id)
        {
            var user = _repository.GetById(id);

            UserDto dto = new UserDto();
            dto.Login = user.Login;
            dto.Role = user.Role;

            return dto;
        }

        public void Create(UserDto userDto)
        {
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User();
            user.Login = userDto.Login;
            user.Role = userDto.Role;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _repository.Create(user);
        }

        public string Login(UserDto dto)
        {
            //HACK: 
            var list = _repository.GetAll();
            var res = new User();

            foreach(User user in list)
            {
                if(user.Login == dto.Login)
                {
                    res = user;
                    break;
                }
            }

            if (res == null)
                throw new NullReferenceException("User with this login wasn`t found");

            if (!VarifyPasswordHash(dto.Password, res))
                throw new Exception("Password incorect");

            string token = CreateToken(res);

            return token;
        }

        public UserDto Update(UserDto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VarifyPasswordHash(string password, User user)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(user.PasswordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
