namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record BillingInfoDto
    {
        public List<InvoiceDto> Invoices { get; set; } = new List<InvoiceDto>();
    }
}
