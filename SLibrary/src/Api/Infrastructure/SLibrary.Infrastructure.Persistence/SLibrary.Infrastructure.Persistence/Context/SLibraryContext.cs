using Microsoft.EntityFrameworkCore;
using SLibrary.Api.Domain.Models;
using System.Reflection;

namespace SLibrary.Infrastructure.Persistence.Context;
public class SLibraryContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";

    #region Constructors
    public SLibraryContext()
    {
    }

    public SLibraryContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
    }
    #endregion

    public DbSet<User> Users { get; set; }

    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //For Design Time Operations! For Example Migrations.
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = "Data Source=127.0.0.1; Initial Catalog=slibrary; Persist Security Info=True; User ID=sa; Password=1Secure*Password1";
            optionsBuilder.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSave()
    {
        var addedEntities = ChangeTracker.Entries()
            .Where(i => i.State == EntityState.Added)
            .Select(i => (BaseEntity)i.Entity);

        PrepareAddedEntites(addedEntities);
    }

    private void PrepareAddedEntites(IEnumerable<BaseEntity> entites)
    {
        foreach (var entity in entites)
        {
            if (entity.CreatedDate == DateTime.MinValue)
                entity.CreatedDate = DateTime.Now;
        }
    }
}

