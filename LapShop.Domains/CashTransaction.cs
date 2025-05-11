namespace LapShop.Domains
{
    public class CashTransaction
    {
        public int CashTransactionId { get; set; }
        public DateTime CashDate { get; set; }
        public decimal CashValue { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
