using Api.Domain.Entities.Catalogs.Example;
using Ardalis.Specification;

namespace Api.Core.Catalogs.Example.Specifications;

public class ExampleSpecification : Specification<CatExample>
{
    public ExampleSpecification(string name)
    {
        Query.AsNoTracking().Where(t => t.Name.Equals(name))

            .OrderBy(x => x.CreatedAt);
    }
    public ExampleSpecification(Guid exampleId)
    {
        Query.AsNoTracking().Where(t => t.ExampleId.Equals(exampleId))
            .OrderBy(x => x.CreatedAt);
    }

    public ExampleSpecification(int page, int pageSize, string Name, bool pagination)
    {
        if (pagination)
        {
            Query.AsNoTracking()
                .Skip((--page) * pageSize)
                .Take(pageSize);
        }
        //En caso de requerir que solo se vean usuarios con Visible y LockoutEnabled = true
        Query.Where(x => x.Visible.Equals(true)); // && x.LockoutEnabled.Equals(true)

        if (!string.IsNullOrEmpty(Name?.Trim()))
        {
            Query.Where(x => x.Name!.ToUpper().Contains(Name.Trim().ToUpper()));
        }
    }
}
