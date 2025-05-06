namespace LapShop.Data.Models
{
    public class SalesInvoicexItem
    {
        public int SalesInvoicexItemId { get; set; }
        public int SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public float Quantity { get; set; }
        public decimal InvoicePrice { get; set; }
        public string? Notes { get; set; }
    }
}
