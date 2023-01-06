using System;
using System.Collections.Generic;
using DomainModel.Content;

namespace DomainModel.Navigation
{
    public class MenuItem : BaseEntity
    {
        public MenuItem()
        {
            Controller = "Page";
            Action = "Index";
        }
        public string Name { get; set; }
        public string StringKey { get; set; }
        public string CustomUrl { get; set; }
        public string AncorUrl { get; set; }
        public string IconClass { get; set; }
        public MenuItemType Type { get; set; }
        
        public string Description { get; set; }

        public bool IsHidden { get; set; }
        public bool isExternal { get; set; }

        public int? PageId { get; set; }
        public virtual Page Page { get; set; }

        public int? ParentId { get; set; }
        public virtual MenuItem Parent { get; set; }

        public virtual IList<MenuItem> Childs { get; set; }

        public int? MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public int Position { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}