using LapShop.Domains.Views;

namespace LapShop.Domains.ViewModels
{
    public class HomepageVM
    {
        public List<VwItems> TopCollections { get; set; } = new List<VwItems>();
        public List<VwItems> NewProducts { get; set; } = new List<VwItems>();
        public List<VwItems> FeaturedProducts { get; set; } = new List<VwItems>();
        public List<VwItems> BestSellers { get; set; } = new List<VwItems>();

        public HomepageVM(List<VwItems> topCollections = null,
                          List<VwItems> newProducts = null,
                          List<VwItems> featuredProducts = null,
                          List<VwItems> bestSellers = null)
        {
            TopCollections = topCollections ?? new List<VwItems>();
            NewProducts = newProducts ?? new List<VwItems>();
            FeaturedProducts = featuredProducts ?? new List<VwItems>();
            BestSellers = bestSellers ?? new List<VwItems>();
        }
    }
}
