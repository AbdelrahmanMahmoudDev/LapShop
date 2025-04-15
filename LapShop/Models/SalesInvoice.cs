namespace LapShop.Models
{
    public class SalesInvoice
    {
        public int SalesInvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int? DeliveryManId { get; set; }
        public DeliveryMan? DeliveryMan { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int CurrentState { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<SalesInvoicexItem> SalesInvoicexItems { get; set; }

    }
}
