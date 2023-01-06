using System;

namespace DomainModel.Content
{
    public class Callback : BaseEntity
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Doc { get; set; }

        public string Comment { get; set; }
        public bool IsNew { get; set; }

        public string LanguageOrig { get; set; }

        public string LanguageTarget { get; set; } 
        // public HttpPostedFileBase File { get; set; }
    }
}