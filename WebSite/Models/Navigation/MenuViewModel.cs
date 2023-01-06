using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models.Navigation
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        public string StringKey { get; set; }

        [Display(Name="Name")]
        public string Name { get; set; }

        public IList<MenuItemViewModel> Items { get; set; }
    }
}
