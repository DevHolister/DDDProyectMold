using Mapster;

namespace Api.Core.Mappings;

internal class ExampleMapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<Source, DestinationDto>()
        //    .Map(dest => dest.UserRoles, src => src.UserRoles!.Select(x => x.Role))
        //    //Nuevo
        //    .Map(dest => dest.Enterprise, src => src.AsocBrancheAreas.Branches.Enterprises.Name)
        //    .Map(dest => dest.Branch, src => src.AsocBrancheAreas.Branches.Name)
        //    .Map(dest => dest.Area, src => src.AsocBrancheAreas.Areas.Name)
        //    .Map(dest => dest.EnterpriseId, src => src.AsocBrancheAreas.Branches.EnterpriseId)
        //    .Map(dest => dest.BranchId, src => src.AsocBrancheAreas.Branches.BranchId)
        //    .Map(dest => dest.AsocBranchAreaId, src => src.AsocBrancheAreas.AsocBranchAreaId)
        //    .Map(dest => dest.LockoutEnabled, src => !(src.LockoutEnd != null && src.LockoutEnd > DateTime.Now));
    }
}
