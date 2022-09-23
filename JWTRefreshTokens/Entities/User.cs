using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWTRefreshTokens.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Key]
        public int UserId { get; set; }
        public List<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
