namespace LapShop.Data.Models
{
    public class CustomerxItem
    {
        public int CustomerxItemId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
