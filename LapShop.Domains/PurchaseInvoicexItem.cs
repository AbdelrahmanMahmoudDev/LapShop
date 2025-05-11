namespace LapShop.Domains
{
    public class PurchaseInvoicexItem
    {
        public int PurchaseInvoicexItemId { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
