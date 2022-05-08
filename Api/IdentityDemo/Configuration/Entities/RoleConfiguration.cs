using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDemo.Configuration.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Id = "9269bda7-25ae-4679-8ba5-49f28a58284a", Name = "Member", NormalizedName = "MEMBER" },
                new IdentityRole { Id = "b894f3e4-0781-4302-9264-a30d6e925973", Name = "Admin", NormalizedName = "ADMIN" }
            );
        }
    }
}
