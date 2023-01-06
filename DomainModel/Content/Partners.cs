using System;

namespace DomainModel.Content
{
   public class Partner : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Company { get; set; }
        public string Activities { get; set; }
        public string Picture { get; set; }
        public bool IsHidden { get; set; }
    }
}
