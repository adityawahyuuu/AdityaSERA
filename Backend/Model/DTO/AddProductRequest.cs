namespace AdityaSERA.Backend.Model.DTO
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? ProductImage { get; set; }

    }
}
