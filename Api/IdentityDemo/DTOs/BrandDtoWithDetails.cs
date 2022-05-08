namespace IdentityDemo.DTOs
{
    public class BrandDtoWithDetails : BrandDto
    {
        public virtual List<CarDto> Cars { get; set; }
    }
}
