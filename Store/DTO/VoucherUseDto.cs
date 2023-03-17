namespace Store
{
    public class VoucherUseDto
    {
        public string VoucherCode { get; set; } = null!;
        public int OrderId { get; set; }
    }
}
