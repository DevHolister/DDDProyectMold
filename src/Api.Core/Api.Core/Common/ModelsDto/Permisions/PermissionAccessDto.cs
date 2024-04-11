namespace Api.Core.Common.ModelsDto.Permisions;

public record PermissionAccessDto(string Module, string Actions)
{
    public IEnumerable<string> Access => Actions.Split(",")
        .Where(x => !string.IsNullOrEmpty(x))
        .Select(x => x.Trim());
}
