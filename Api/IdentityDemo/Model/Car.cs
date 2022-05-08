namespace IdentityDemo.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }


        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
