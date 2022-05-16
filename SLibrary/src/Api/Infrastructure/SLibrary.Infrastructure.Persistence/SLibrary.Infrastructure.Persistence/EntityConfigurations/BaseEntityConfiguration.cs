using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLibrary.Api.Domain.Models;

namespace SLibrary.Infrastructure.Persistence.EntityConfigurations;
public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
    }
}

