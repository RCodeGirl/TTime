using DomainModel.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Content
{
    public class CallBackViewModelcs
    {
        public int? Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

       
        public string Phone { get; set; }

       
        public string LanguageOrig { get; set; }

       
        public string LanguageTarget { get; set; }

       
        public string Comment { get; set; }

        public bool IsNew { get; set; }
         
        public string Doc { get; set; }

      
        public IFormFile Document { get; set; }

        public static CallBackViewModelcs FromDomainModel(Callback callback)
        {
            
            var result = new CallBackViewModelcs
            {
                Id = callback.Id,
                Name = callback.Name,
                Phone = callback.Phone,
                Email= callback.Email,
                LanguageOrig = callback.LanguageOrig,
                LanguageTarget= callback.LanguageTarget,
                Comment= callback.Comment

            };

            return result;
        }

    }
}
