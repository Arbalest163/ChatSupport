using ChatSupport.Application.Interfaces;
using ChatSupport.Domain;
using ChatSupport.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ChatSupport.Persistence
{
    public class ChatSupportDbContext : DbContext, IChatSupportDbContext
    {
        public ChatSupportDbContext(DbContextOptions<ChatSupportDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Chat> Chats => Set<Chat>();
        public DbSet<Message> Messages => Set<Message>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public void Migrate()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Users.AddRange(DataProvider.GetUsers());
            //SaveChanges();
            //Database.Migrate();
        }
    }
}
