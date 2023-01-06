using DomainModel.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models.Content
{
    public class BlockListViewModel
    { 
        public int Id { get; set; }
        public string StringKey { get; set; }

        /// <summary>
        ///     заголовок списка блоков
        /// </summary>
        public string Name { get; set; }
        public int Pozition { get; set; }

        public IList<Block> Blocks { get; set; }
      
    }
}
