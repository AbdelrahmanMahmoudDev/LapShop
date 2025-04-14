namespace LapShop.Models
{
    public class ItemDiscount
    {
        public int ItemDiscountId { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime EndDate { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
