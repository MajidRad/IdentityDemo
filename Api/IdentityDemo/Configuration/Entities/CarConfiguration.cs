using IdentityDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Configuration.Entities
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new Car { Id = 1, Name = "sls mcLaren", Price = 500000, CreatedDate = new DateTime(2010, 3, 10), BrandId = 1 },
                new Car { Id = 2, Name = "sl 500", Price = 240000, CreatedDate = new DateTime(2010, 3, 10), BrandId = 1 },
                new Car { Id = 3, Name = "x3", Price = 54000, CreatedDate = new DateTime(2010, 3, 10), BrandId = 2 },
                new Car { Id = 4, Name = "x4", Price = 66000, CreatedDate = new DateTime(2010, 3, 10), BrandId = 2 },
                new Car { Id = 5, Name = "x6", Price = 75000, CreatedDate = new DateTime(2010, 3, 10), BrandId = 2 },
                new Car { Id = 6, Name = "mustang", Price = 44000, CreatedDate = new DateTime(2010, 3, 10), BrandId = 3 }
                );
        }
    }
}
