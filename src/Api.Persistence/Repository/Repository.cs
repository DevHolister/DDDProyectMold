using Api.Core.Common.Interfaces.Persistence;
using Api.Persistence.Context;
using Ardalis.Specification.EntityFrameworkCore;

namespace Api.Persistence.Repository;

public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    private readonly ApplicationDbContext dbContext;

    public Repository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    public void ClearTracking()
    {
        dbContext.ChangeTracker.Clear();
    }
}
