using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Common
{
    public class SideMenuItemViewModel
    {
        public SideMenuItemViewModel()
        {
            Action = "Index";
            Childs = new List<SideMenuItemViewModel>();
        }

        public string Controller { get; set; }
        public string Action { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }
        public bool IsActive { get; set; }

        public object Params { get; set; }

        public List<SideMenuItemViewModel> Childs { get; set; }
    }
}

