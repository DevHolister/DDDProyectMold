namespace Api.Domain.Common;

public static class CatalogPermission
{
    public const string ReadUser = "User:Read";
    public const string CreateUser = "User:Create";
    public const string WriteUser = "User:Write";
    public const string DeleteUser = "User:Delete";
    public const string ExportUser = "User:Export";
    public const string ReadRole = "Role:Read";
    public const string CreateRole = "Role:Create";
    public const string WriteRole = "Role:Write";
    public const string DeleteRole = "Role:Delete";
    public const string ExportRole = "Role:Export";
    public const string Root = "Root:*";    
}
