using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Common;

namespace Api.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ApplicationDbContext> _logger;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IConfiguration configuration,
        ILogger<ApplicationDbContext> logger) : base(options)
    {
        _configuration = configuration;
        _logger = logger;
    }

    //Example
    //public DbSet<Entity> Entity {  get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity> entry in ChangeTracker.Entries<Entity>())
        {
            switch (entry.State)
            {
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.Now;
                    entry.Entity.ModifiedBy = Guid.Parse("98523425-646A-4D96-D155-08DB982FB8E0"); //Guid.Parse(this._currentUserService.UserId);
                    break;
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.CreatedBy = entry.Entity.CreatedBy = !entry.Entity.SpecifyCreatedBy ? Guid.Parse("98523425-646A-4D96-D155-08DB982FB8E0") : entry.Entity.CreatedBy;
                    //Guid.Parse(this._currentUserService.UserId)
                    entry.Entity.ModifiedAt = DateTime.Now;
                    entry.Entity.ModifiedBy = entry.Entity.ModifiedBy = !entry.Entity.SpecifyCreatedBy ? Guid.Parse("98523425-646A-4D96-D155-08DB982FB8E0") : entry.Entity.ModifiedBy;
                    //Guid.Parse(this._currentUserService.UserId)
                    break;
                default:
                    break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
