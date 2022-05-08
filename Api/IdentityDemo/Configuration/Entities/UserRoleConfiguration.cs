using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDemo.Configuration.Entities
{
    //new IdentityRole { Id = "9269bda7-25ae-4679-8ba5-49f28a58284a", Name = "Member"},
    //new IdentityRole { Id = "b894f3e4-0781-4302-9264-a30d6e925973", Name = "Admin"}
    //new User { Id = "4049ff33-6e91-46d4-b747-4be3e6681731", UserName = "admin" },
    //new User { Id = "ebe9598f-616d-4e7f-9b38-0f841cc39883", UserName = "bob",  },
    //new User { Id = "14f7b1d7-6325-4b7d-afc2-18ebdf63ce72", UserName = "majid",  }

    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                //member bob
                new IdentityUserRole<string>
                {
                    RoleId = "9269bda7-25ae-4679-8ba5-49f28a58284a",
                    UserId = "ebe9598f-616d-4e7f-9b38-0f841cc39883",
                },
                //admin admin
                new IdentityUserRole<string>
                {
                    RoleId = "b894f3e4-0781-4302-9264-a30d6e925973",
                    UserId = "4049ff33-6e91-46d4-b747-4be3e6681731",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "9269bda7-25ae-4679-8ba5-49f28a58284a",
                    UserId = "4049ff33-6e91-46d4-b747-4be3e6681731",
                },
                //admin majid
                new IdentityUserRole<string>
                {
                    RoleId = "9269bda7-25ae-4679-8ba5-49f28a58284a",
                    UserId = "14f7b1d7-6325-4b7d-afc2-18ebdf63ce72",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "b894f3e4-0781-4302-9264-a30d6e925973",
                    UserId = "14f7b1d7-6325-4b7d-afc2-18ebdf63ce72",
                }

                );
        }
    }
}
