using Microsoft.EntityFrameworkCore;
using NotificationService.DTO;

namespace NotificationService.Context
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }
        public DbSet<NotificationDto> Notifications { get; set; }
    }

}
