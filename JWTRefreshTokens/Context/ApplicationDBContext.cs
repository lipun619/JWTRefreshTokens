using JWTRefreshTokens.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTRefreshTokens.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
