using System.Collections.Generic;

namespace DomainModel.Navigation
{
    public class Menu : BaseEntity
    {
        public string StringKey { get; set; }

        public string Name { get; set; }

        public virtual IList<MenuItem> Items { get; set; }
    }
}