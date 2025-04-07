using Microsoft.EntityFrameworkCore;
using UserService.DTO;

namespace UserService.Context
{

    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<RoleMaster> Roles { get; set; }
    }
}


