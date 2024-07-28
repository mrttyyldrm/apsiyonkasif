namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record InvoiceDto
    {
        public decimal Amount { get; set; }
        public string InvoiceTypeName { get; set; }
        public string Icon { get; set; }
    }
}
