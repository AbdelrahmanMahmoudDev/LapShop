using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShop.Domains
{
    public class TextBox
    {
        public string Header { get; set; } = null!;
        public string SubHeader { get; set; } = null!;
    }
    public class HomepageSettings
    {
        public string LogoUrl { get; set; } = null!;
        public string FaviconUrl { get; set; } = null!;
        public TextBox HeroText { get; set; } = null!;
        public TextBox LeftCategoryText { get; set; } = null!;
        public TextBox RightCategoryText { get; set; } = null!;
    }
}
