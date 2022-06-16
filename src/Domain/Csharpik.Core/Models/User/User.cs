using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpik.Core.Models.User
{
    public class User
    {

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [MaxLength(10)]
        public string Role { get; set; }
    }
}
