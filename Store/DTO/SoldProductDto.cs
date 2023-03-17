namespace Store
{
    public class SoldProductDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string ProductName { get; set; } = null!;

        public string AuthName { get; set; } = null!;

        public DateTime DateTime { get; set; }
    }
}
