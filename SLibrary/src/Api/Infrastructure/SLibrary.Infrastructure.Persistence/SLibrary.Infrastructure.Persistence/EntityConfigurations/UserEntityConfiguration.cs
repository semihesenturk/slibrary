using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLibrary.Api.Domain.Models;
using SLibrary.Infrastructure.Persistence.Context;

namespace SLibrary.Infrastructure.Persistence.EntityConfigurations;
public class UserEntityConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("user", SLibraryContext.DEFAULT_SCHEMA);
    }
}
