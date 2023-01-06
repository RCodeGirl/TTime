using DomainModel.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Content
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string StringKey { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Annonse { get; set; }
        public string Description { get; set; }

        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        public string ImgPreview { get; set; }
        public string ImgLarge { get; set; }
        public bool IsHidden { get; set; }

     
        

        public IFormFile Photo { get; set; }
    }
}
