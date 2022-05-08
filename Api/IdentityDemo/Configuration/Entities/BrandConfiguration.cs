using IdentityDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDemo.Configuration.Entities
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { Id = 1, Name = "Benz" },
                new Brand { Id = 2, Name = "Bmw" },
                new Brand { Id = 3, Name = "Ford" }
                );
        }
    }
}
