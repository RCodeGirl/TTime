using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Content;
using WebSite.Models.Navigation;

namespace WebSite.Models.Content
{
    public class PageMenuItemViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; } = new();
        public MenuItemViewModel MenuItem { get; set; } 
        public PageViewModel Page { get; set; }
        public CallBackViewModelcs Call { get; set; }
        public List<SaleViewModel> Otzivi { get; set; } = new();
        public List<QuestionViewModel> Question { get; set; } = new();
        public List<BlockViewModel> Block { get; set; } = new();
    }

    
}
