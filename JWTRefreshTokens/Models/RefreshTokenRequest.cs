using System.ComponentModel.DataAnnotations;

namespace JWTRefreshTokens.Models
{
    public class RefreshTokenRequest
    {
        [Required]
        public string ExpiredToken { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
