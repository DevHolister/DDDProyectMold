using Api.Domain.Entities.Catalogs.Example;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistence.Configuration.Catalogs;

internal class CatExampleConfiguration : IEntityTypeConfiguration<CatExample>
{
    public void Configure(EntityTypeBuilder<CatExample> builder)
    {
        builder.ToTable("CAT_EXAMPLE");
        builder.Property(x => x.ExampleId).ValueGeneratedOnAdd();
        builder.HasKey(x => x.ExampleId);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.ModifiedBy);
        builder.Property(x => x.ModifiedAt);
        builder.Property(x => x.Visible);
        builder.Ignore(x => x.SpecifyCreatedBy);

        //RelationsExample1
        //builder.HasMany(x => x.Branches)
        //.WithOne(x => x.Enterprises)
        //.HasForeignKey(x => x.EnterpriseId)
        //.IsRequired();

        //RelationsExample2
        //builder.HasMany(x => x.Areas)
        //.WithOne(x => x.Enterprises)
        //.HasForeignKey(x => x.EnterpriseId)
        //.IsRequired();
    }
}
