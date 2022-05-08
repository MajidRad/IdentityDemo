using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityDemo.Configuration.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = "4049ff33-6e91-46d4-b747-4be3e6681731",
                    UserName = "admin",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "Majid@123")
                },
                new User
                {
                    Id = "ebe9598f-616d-4e7f-9b38-0f841cc39883",
                    UserName = "bob",
                    Email = "bob@test.com",
                    NormalizedEmail="BOB@TEST.COM",
                    NormalizedUserName = "BOB",
                    PasswordHash = hasher.HashPassword(null, "Majid@123")
                },
                new User
                {
                    Id = "14f7b1d7-6325-4b7d-afc2-18ebdf63ce72",
                    UserName = "majid",
                    Email = "majid@test.com",
                    NormalizedEmail="MAJID@TEST.COM",
                    NormalizedUserName="MAJID",
                    PasswordHash = hasher.HashPassword(null, "Majid@123")
                }
                );


        }
    }
}
