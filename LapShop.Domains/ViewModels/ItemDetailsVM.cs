using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShop.Domains.ViewModels
{
    public class ItemDetailsVM
    {
        public ItemDetailsVM()
        {
            RelatedProducts = new List<Item>();
        }
        public VwItemsVM Item { get; set; } = null!;
        public ICollection<Item> RelatedProducts { get; set; }
    }
}
