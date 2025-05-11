namespace LapShop.Domains
{
    public class DeliveryMan
    {
        public int DeliveryManId { get; set; }
        public string DeliveryManName { get; set; }
        public List<SalesInvoice> SalesInvoices { get; set; }
    }
}
