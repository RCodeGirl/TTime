using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Content
{
     public class Question:BaseEntity
    {
        public  string StringKey { get; set; }
        public string question { get; set; }
        public string Answer { get; set; }
        

    }
}
