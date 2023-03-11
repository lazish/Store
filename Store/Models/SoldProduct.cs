using System.Text.Json.Serialization;

namespace Store
{
    public class SoldProduct
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string ProductName { get; set; }

        [JsonIgnore]
        public Auth Auth { get; set; }

        public int AuthId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
