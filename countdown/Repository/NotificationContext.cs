using Microsoft.EntityFrameworkCore;

namespace countdown.Repository
{
    public class NotificationContext : DbContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> options)
           : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Notification> Notifications { get; set; }
    }
}
