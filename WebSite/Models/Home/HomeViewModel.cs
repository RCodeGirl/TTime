using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Content;

namespace WebSite.Models.Home
{
    public class HomeViewModel
    {
       
        public List<SliderViewModel> Sliders { get; set; } = new();
        public List<ArticleViewModel> Articles { get; set; } = new();
        public List<PartnersViewModel> Partners { get; set; } = new();
        public PageViewModel PageView { get; set; }

    }
}
