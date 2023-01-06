using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Content
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string StringKey { get; set; }
        public string question { get; set; }
        public string Answer { get; set; }
    }
}
