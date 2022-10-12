namespace ChatSupport.Application.Interfaces;
public interface IChatSupportDbContext
{
    DbSet<User> Users { get; }
    DbSet<Chat> Chats { get; }
    DbSet<Message> Messages { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
