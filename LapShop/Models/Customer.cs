namespace LapShop.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<BusinessInfo> BusinessInfo { get; set; }
        public List<CashTransaction> CashTransactions { get; set; }
        public List<CustomerxItem> CustomerxItems { get; set; } 
        public List<SalesInvoice> SalesInvoices { get; set; }
    }
}
