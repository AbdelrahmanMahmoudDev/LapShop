namespace LapShop.Domains
{
    public class PurchaseInvoice
    {
        public int PurchaseInvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? Notes { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<PurchaseInvoicexItem> PurchaseInvoicexItems { get; set; }
    }
}
