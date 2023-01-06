using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Content
{
    public class PartnersViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название Партнера")]
        public string Name { get; set; }
        public string Url { get; set; }
        [Display(Name = "Название Компании(Не обязательно):")]
        public string Company { get; set; }
        public string Activities { get; set; }
        
        public string Picture { get; set; }
        public bool IsHidden { get; set; }
        [Display(Name = "Загрузите фото партнера:")]
        public IFormFile Photo { get; set; }
    }

}

