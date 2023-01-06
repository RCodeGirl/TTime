using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebSite.Models.Content
{
    public class SaleViewModel
    {
        public string StringKey { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        public string ImgPreview { get; set; }
        
        public bool IsHidden { get; set; }

        public IFormFile Photo { get; set; }
}
}
