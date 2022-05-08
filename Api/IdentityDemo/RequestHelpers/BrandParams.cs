namespace IdentityDemo.RequestHelpers
{
    public class BrandParams : PaginationParams
    {
        public string? OrderBy { get; set; } = "";
        public string? SearchTerm { get; set; } = "";
    }
}
