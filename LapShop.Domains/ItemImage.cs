namespace LapShop.Domains
{
    public class ItemImage
    {
        public int ItemImageId { get; set; }
        public string ItemImageName { get; set; }
        public int ItemId { get; set; }
        public Item Item;
    }
}
