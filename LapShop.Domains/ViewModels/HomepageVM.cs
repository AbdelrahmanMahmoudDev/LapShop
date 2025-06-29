using LapShop.Domains.Views;

namespace LapShop.Domains.ViewModels
{
    public class HomepageVM
    {
        public List<Item> TopCollections { get; set; } = new List<Item>();
        public List<Item> NewProducts { get; set; } = new List<Item>();
        public List<Item> FeaturedProducts { get; set; } = new List<Item>();
        public List<Item> BestSellers { get; set; } = new List<Item>();
        public List<Slider> Sliders { get; set; } = new List<Slider>();

        public HomepageVM(List<Item> topCollections = null,
                          List<Item> newProducts = null,
                          List<Item> featuredProducts = null,
                          List<Item> bestSellers = null,
                          List<Slider> sliders = null)
        {
            TopCollections = topCollections ?? new List<Item>();
            NewProducts = newProducts ?? new List<Item>();
            FeaturedProducts = featuredProducts ?? new List<Item>();
            BestSellers = bestSellers ?? new List<Item>();
            Sliders = sliders ?? new List<Slider>();
        }
    }
}
