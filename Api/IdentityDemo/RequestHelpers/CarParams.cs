namespace IdentityDemo.RequestHelpers
{
    public class CarParams : PaginationParams
    {
        public string orderBy { get; set; } = "";
        public string SearchTerm { get; set; } = "";

        //public string Brands { get; set; }
    }
}
