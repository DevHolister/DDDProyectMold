using Api.Domain.Common;

namespace Api.Domain.Entities.Catalogs.Example;

public class CatExample : Entity
{
    public Guid ExampleId { get; set; }
    public string Name { get; set; }
}
