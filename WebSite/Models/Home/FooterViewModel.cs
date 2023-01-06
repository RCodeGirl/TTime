using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Content;
using WebSite.Models.Navigation;

namespace WebSite.Models.Home
{
    public class FooterViewModel
    {
        public List<BlockListViewModel> BlocLists { get; set; } = new();
        public List<MenuItemViewModel> MenuItems { get; set; } = new();
    }
}
