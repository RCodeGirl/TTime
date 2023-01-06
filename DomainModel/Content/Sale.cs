using System;
using System.Collections.Generic;

namespace DomainModel.Content
{
    public class Sale : BaseEntity
    {
        public string StringKey { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        public string ImgPreview { get; set; }
        public string ImgLarge { get; set; }
        public bool IsHidden { get; set; }
    }
}