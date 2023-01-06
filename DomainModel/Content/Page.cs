using System;
using System.Collections.Generic;
using DomainModel.Navigation;

namespace DomainModel.Content
{
    public class Page : BaseEntity
    {
        public Page()
        {
            MenuItems = new List<MenuItem>();
        }

        public string StringKey { get; set; }
        //public bool IsHidden { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }

        public bool IsSection { get; set; }

        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        
        public virtual IList<MenuItem> MenuItems { get; set; }
    }
}