using Ardalis.Specification;

namespace Api.Core.Common.Interfaces.Persistence;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
    public void ClearTracking();
}
