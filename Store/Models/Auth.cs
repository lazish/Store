using System;
using System.Text.Json.Serialization;

namespace Store
{
    public class Auth
    {
		public int Id { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string Role { get; set; } = "user";

		public List<Product>? Products { get; set; }

		public List<Order>? Orders { get; set; }

		public List<Voucher>? Vouchers { get; set; }

		public List<SoldProduct>? SoldProducts { get; set; }
	}
}
