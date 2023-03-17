namespace Store
{
    public class SoldUserDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string ProductName { get; set; } = null!;

        public DateTime DateTime { get; set; }
    }
}
