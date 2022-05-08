using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.DTOs
{
    public class CarDtoWithDetails : CarDto
    {
        public RegisterBrandDto Brand { get; set; }

    }
}
