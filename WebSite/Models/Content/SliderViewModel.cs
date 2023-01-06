using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Content
{
    public class SliderViewModel
    {
        public int Id { get; set; }
        public bool IsHidden { get; set; }
        [Display(Name = "Короткое описание")]
        public string Title { get; set; }
        
        public string Image { get; set; }

        [Display(Name = "Основной Текст")]
        public string Description { get; set; }
                
        public string Url { get; set; }

        
        [Display(Name = "Загрузите слайдер")]
        public IFormFile Photo { get; set; }
        
        public IEnumerable<SliderViewModel> Sliders { get; set; } 
}
}
