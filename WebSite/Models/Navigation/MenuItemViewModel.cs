using DomainModel.Content;
using DomainModel.Navigation;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models.Navigation
{
    public class MenuItemViewModel
    {
        public MenuItemViewModel()
        {
            Action = "Index";
            Controller = "Page";
        }

        public int Position { get; set; }
        public int Id { get; set; }

        [Display(Name = "Order")]
        public int Order { get; set; }
        [Display(Name = "Выберите Родителя:")]
        public int? ParentId { get; set; }
        public MenuItem Parent { get; set; }
        public IList<MenuItem> Childs { get; set; }
        public string IconClass { get; set; }

        public int? MenuId { get; set; }
        public string StringKey { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public string Description { get; set; }

        public bool isExternal { get; set; }

        [Display(Name = "External reference")]
        public string CustomUrl { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Is hidden")]
        public bool IsHidden { get; set; }
        [Display(Name = "Выберите страницу:")]
        public int? PageId { get; set; }
        public IFormFile Icon { get; set; }
        public PageViewModel Page { get; set; }
        public MenuItemType Type { get; set; }

        //public BlockList BlockList { get; set; }
        //public string BlockListKey { get; set; }

        public List<PageViewModel> Pages { get; set; }
        public List<MenuItemViewModel> MenuItems { get; set; }
        public List<MenuViewModel> Menus { get; set; }
    }
}
