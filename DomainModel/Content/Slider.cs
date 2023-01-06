using System;

namespace DomainModel.Content
{
    public class Slider : BaseEntity
    {
        public bool IsHidden { get; set; }

        public string Title { get; set; }
         
        public string Description  { get; set; }
       
        public string Image { get; set; }
        public string Url { get; set; }
    }
}