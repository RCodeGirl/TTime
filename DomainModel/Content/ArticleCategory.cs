using System;
using System.Collections.Generic;

namespace DomainModel.Content
{
    public class ArticleCategory : BaseEntity
    {
        //public ArticleCategory()
        //{
        //    Articles = new List<Article>();
        //}

        public string StringKey { get; set; }

        public string Name { get; set; }

        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        //public IList<Article> Articles { get; set; }
    }
}