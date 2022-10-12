using ChatSupport.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatSupport.Persistence.EntityTypeConfigurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(n => n.FirstName).IsRequired();
        builder.Property(n => n.LastName).IsRequired();
        builder.Property(n => n.Birthday).IsRequired();
    }
}
