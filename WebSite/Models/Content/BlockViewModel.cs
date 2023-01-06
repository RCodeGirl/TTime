using DomainModel.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Content
{
    public class BlockViewModel
    {
        public int Id { get; set; }
        public string StringKey { get; set; }

        public bool IsStatic { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsHidden { get; set; }

        public int Pozition { get; set; }

        public string Img { get; set; }

        public bool IsContent { get; set; }

        public int? BlockListId { get; set; }
        public  BlockList BlockList { get; set; }

        public  List <BlockListViewModel> BlockLists { get; set; }

        public IFormFile Icon { get; set; }

    }
}
