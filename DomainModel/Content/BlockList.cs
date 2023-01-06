using System.Collections.Generic;

namespace DomainModel.Content
{
    public class BlockList : BaseEntity
    {
        /// <summary>
        ///     ключ
        /// </summary>
        public string StringKey { get; set; }

        /// <summary>
        ///     заголовок списка блоков
        /// </summary>
        public string Name { get; set; }

        public virtual IList<Block> Blocks { get; set; }
        public int Pozition { get; set; }
    }
}