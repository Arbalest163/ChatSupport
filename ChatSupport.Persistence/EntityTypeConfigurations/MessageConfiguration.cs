using ChatSupport.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChatSupport.Persistence.EntityTypeConfigurations;
public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.NoAction);
    }
}
