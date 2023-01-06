using DomainModel.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models.Content;
using WebSite.Models.Navigation;

namespace WebSite.Models.Home
{
    public class HomeMenuViewModel
    {
        public List<MenuItemViewModel> MenuItems { get; set; } = new();
        public List<BlockViewModel> Blocks { get; set; } = new();
    }
}
